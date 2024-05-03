// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LargeIronChestItemFactory : ChestItemFactory
{
    private LargeIronChestItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Large iron chest";

    public override int Cost => 150;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "& Large iron chest~";
    public override int LevelNormallyFound => 35;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (35, 1)
    };
    public override int Weight => 1000;
    public override bool IsSmall => false;
    public override int NumberOfItemsContained => 4;
    public override Item CreateItem() => new Item(Game, this);
}
