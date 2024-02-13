// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class GlovesArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the hands inventory slots for gloves.
    /// </summary>
    public override int WieldSlot => InventorySlot.Hands;
    public GlovesArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(GlovesItemClass));

    /// <summary>
    /// Applies a good random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (SaveGame.DieRoll(10))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfFreeActionRareItem));
                break;
            case 5:
            case 6:
            case 7:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfSlayingRareItem));
                break;
            case 8:
            case 9:
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfAgilityRareItem));
                break;
            case 10:
                IArtifactBias artifactBias = null;
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfPowerRareItem));
                item.ApplyRandomResistance(ref artifactBias, SaveGame.DieRoll(22) + 16);
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to gloves.
    /// </summary>
    /// <param name="item"></param>
    protected override void ApplyRandomPoorRareCharacteristics(Item item)
    {
        switch (SaveGame.DieRoll(2))
        {
            case 1:
                {
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfClumsinessRareItem));
                    break;
                }
            default:
                {
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(GlovesOfWeaknessRareItem));
                    break;
                }
        }
    }

    /// <summary>
    /// Applies standard magic to gloves.
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
                if (SaveGame.DieRoll(20) == 1)
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
    public override int PackSort => 26;
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(HandsInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gloves;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBrown;

}
