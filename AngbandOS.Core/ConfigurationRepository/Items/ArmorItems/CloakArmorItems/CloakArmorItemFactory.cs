// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class CloakArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the about body inventory slot for cloaks.
    /// </summary>
    public override int WieldSlot => InventorySlot.AboutBody;

    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>(SaveGame);
        weightedRandom.Add(8, RareItemTypeEnum.CloakOfProtection);
        weightedRandom.Add(8, RareItemTypeEnum.CloakOfStealth);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfAman);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfElectricity);
        weightedRandom.Add(1, RareItemTypeEnum.CloakOfImmolation);
        item.RareItemTypeIndex = weightedRandom.Choose();
    }

    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(3))
        {
            case 1:
                item.RareItemTypeIndex = RareItemTypeEnum.CloakOfIrritation;
                break;
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.CloakOfVulnerability;
                break;
            case 3:
                item.RareItemTypeIndex = RareItemTypeEnum.CloakOfEnveloping;
                break;
        }
    }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                if (SaveGame.Rng.DieRoll(20) == 1)
                {
                    item.CreateRandart(false);
                }
                else
                {
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
            else if (power < -1)
            {
                ApplyRandomPoorRareCharacteristics(item);
            }
        }
    }

    public CloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(CloaksItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(AboutBodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Cloak;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override int PackSort => 22;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;

    public override bool CanReflectBoltsAndArrows => true;

    public override bool CanApplyArtifactBiasResistance => true;
}
