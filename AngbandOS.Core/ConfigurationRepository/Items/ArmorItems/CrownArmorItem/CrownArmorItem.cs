// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class CrownArmorItem : ArmourItem
{
    public override int WieldSlot => InventorySlot.Head;
    public CrownArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }


    protected override void ApplyRandomGoodRareCharacteristics()
    {
        IArtifactBias artifactBias = null;
        switch (SaveGame.Rng.DieRoll(8))
        {
            case 1:
                RareItemTypeIndex = RareItemTypeEnum.HatOfTheMagi;
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 2:
                RareItemTypeIndex = RareItemTypeEnum.HatOfMight;
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 3:
                RareItemTypeIndex = RareItemTypeEnum.HatOfTelepathy;
                break;
            case 4:
                RareItemTypeIndex = RareItemTypeEnum.HatOfRegeneration;
                break;
            case 5:
            case 6:
                RareItemTypeIndex = RareItemTypeEnum.HatOfLordliness;
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 7:
            case 8:
                RareItemTypeIndex = RareItemTypeEnum.HatOfSeeing;
                if (SaveGame.Rng.DieRoll(3) == 1)
                {
                    RandartItemCharacteristics.Telepathy = true;
                }
                break;
        }
    }

    protected override void ApplyRandomPoorRareCharacteristics()
    {
        switch (SaveGame.Rng.DieRoll(7))
        {
            case 1:
            case 2:
                RareItemTypeIndex = RareItemTypeEnum.HatOfStupidity;
                break;
            case 3:
            case 4:
                RareItemTypeIndex = RareItemTypeEnum.HatOfNaivety;
                break;
            case 5:
                RareItemTypeIndex = RareItemTypeEnum.HatOfUgliness;
                break;
            case 6:
                RareItemTypeIndex = RareItemTypeEnum.HatOfSickliness;
                break;
            case 7:
                RareItemTypeIndex = RareItemTypeEnum.HatOfTeleportation;
                break;
        }
    }

    /// <summary>
    /// Applies standard magic to crowns.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armour characteristics.
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