// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SmallMetalShieldArmorItemFactory : ShieldArmorItemFactory
{
    private SmallMetalShieldArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Small Metal Shield";

    public override int ArmorClass => 3;
    public override int Cost => 50;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "& Small Metal Shield~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 65;
    public override Item CreateItem() => new Item(Game, this);
}
