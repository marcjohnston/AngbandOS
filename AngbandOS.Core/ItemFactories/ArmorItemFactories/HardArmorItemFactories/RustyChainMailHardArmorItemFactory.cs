// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RustyChainMailHardArmorItemFactory : HardArmorItemFactory
{
    private RustyChainMailHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Rusty Chain Mail";

    public override int ArmorClass => 14;
    public override int Cost => 550;
    public override int DamageDice => 1;
    public override int DamageSides => 4;
    public override string FriendlyName => "Rusty Chain Mail~";
    public override int LevelNormallyFound => 25;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (25, 1)
    };
    public override int BonusArmorClass => -8;
    public override int BonusHit => -5;
    public override int Weight => 200;
    public override Item CreateItem() => new Item(Game, this);
}
