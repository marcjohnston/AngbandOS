// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GauntletGlovesArmorItemFactory : GlovesArmorItemFactory
{
    private GauntletGlovesArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Set of Gauntlets";

    public override int ArmorClass => 2;
    public override int Cost => 35;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "& Set~ of Gauntlets";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 25;
    public override Item CreateItem() => new Item(Game, this);
}
