// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class CloakArmorItem : ArmorItem
{
    public CloakArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    protected override void ApplyRandomGoodRareCharacteristics()
    {
        WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>(SaveGame);
        weightedRandom.Add(8, RareItemTypeEnum.CloakOfProtection);
        weightedRandom.Add(8, RareItemTypeEnum.CloakOfStealth);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfAman);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfElectricity);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfImmolation);
        RareItemTypeIndex = weightedRandom.Choose();
    }


    protected override void ApplyRandomPoorRareCharacteristics()
    {
        switch (SaveGame.Rng.DieRoll(3))
        {
            case 1:
                RareItemTypeIndex = RareItemTypeEnum.CloakOfIrritation;
                break;
            case 2:
                RareItemTypeIndex = RareItemTypeEnum.CloakOfVulnerability;
                break;
            case 3:
                RareItemTypeIndex = RareItemTypeEnum.CloakOfEnveloping;
                break;
        }
    }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(level, power, null);

            if (power > 1)
            {
                if (SaveGame.Rng.DieRoll(20) == 1)
                {
                    CreateRandart(false);
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics();
                }
            }
            else if (power < -1)
            {
                ApplyRandomPoorRareCharacteristics();
            }
        }
    }
}