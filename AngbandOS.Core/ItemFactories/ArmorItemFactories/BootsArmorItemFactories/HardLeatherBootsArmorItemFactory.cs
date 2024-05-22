// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HardLeatherBootsArmorItemFactory : BootsArmorItemFactory
{
    private HardLeatherBootsArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Pair of Hard Leather Boots";

    public override int ArmorClass => 3;
    public override int Cost => 12;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Pair~ of Hard Leather Boots";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 40;

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
