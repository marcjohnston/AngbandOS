// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class HelmArmorItemFactory : ArmorItemFactory
{

    /// <summary>
    /// Applies standard magic to helms.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
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

    /// <summary>
    /// Returns the head inventory slot for helms.
    /// </summary>
    public override int WieldSlot => InventorySlot.Head;
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(14))
        {
            case 1:
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfIntelligence;
                break;
            case 3:
            case 4:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfWisdom;
                break;
            case 5:
            case 6:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfBeauty;
                break;
            case 7:
            case 8:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfSeeing;
                if (SaveGame.Rng.DieRoll(7) == 1)
                {
                    item.RandartItemCharacteristics.Telepathy = true;
                }
                break;
            case 9:
            case 10:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfLight;
                break;
            case 11:
            case 12:
            case 13:
            case 14:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfInfravision;
                break;
        }
    }


    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.Rng.DieRoll(7))
        {
            case 1:
            case 2:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfStupidity;
                break;
            case 3:
            case 4:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfNaivety;
                break;
            case 5:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfUgliness;
                break;
            case 6:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfSickliness;
                break;
            case 7:
                item.RareItemTypeIndex = RareItemTypeEnum.HatOfTeleportation;
                break;
        }
    }

    public HelmArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(HelmsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(HeadInventorySlot));
    public override int PackSort => 25;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Helm;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override bool CanReflectBoltsAndArrows => true;
}
