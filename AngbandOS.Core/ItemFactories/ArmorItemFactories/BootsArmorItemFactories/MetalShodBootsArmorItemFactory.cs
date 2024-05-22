// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MetalShodBootsArmorItemFactory : BootsArmorItemFactory
{
    private MetalShodBootsArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Pair of Metal Shod Boots";

    public override int ArmorClass => 6;
    public override int Cost => 50;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Pair~ of Metal Shod Boots";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 80;

    /// <summary>
    /// Returns the feet inventory slot for boots.
    /// </summary>
    public override int WieldSlot => InventorySlot.Feet;

    protected override string ItemClassName => nameof(BootsItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(FeetInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Boots;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override int PackSort => 27;
}
