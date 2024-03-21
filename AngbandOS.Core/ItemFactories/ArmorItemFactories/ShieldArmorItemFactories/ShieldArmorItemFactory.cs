// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class ShieldArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the arm inventory slot for shields.
    /// </summary>
    public override int WieldSlot => InventorySlot.Arm;

    /// <summary>
    /// Applies a good random rare characteristics to a shield.
    /// </summary>
    protected override void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(23))
        {
            case 1:
            case 11:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfResistAcidRareItem));
                break;
            case 2:
            case 3:
            case 4:
            case 12:
            case 13:
            case 14:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfResistLightningRareItem));
                break;
            case 5:
            case 6:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfResistFireRareItem));
                break;
            case 7:
            case 8:
            case 9:
            case 17:
            case 18:
            case 19:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfResistColdRareItem));
                break;
            case 10:
            case 20:
                IArtifactBias artifactBias = null;
                item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(34) + 4);
                if (Game.DieRoll(4) == 1)
                {
                    item.RandomArtifactItemCharacteristics.ResPois = true;
                }
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfResistanceRareItem));
                break;
            case 21:
            case 22:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ShieldOfReflectionRareItem));
                break;
            case 23:
                item.CreateRandomArtifact(false);
                break;
        }
    }

    /// <summary>
    /// Applies standard magic to shields.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="power"></param>
    /// <param name="store"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                ApplyRandomGoodRareCharacteristics(item);
            }
        }
    }
    public ShieldArmorItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.ItemClasses.Get(nameof(ShieldsItemClass));
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(ArmInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shield;
    public override int PackSort => 23;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.BrightBrown;

    public override bool CanReflectBoltsAndArrows => true;
}
