// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HumanSkeletonSkeletonItemFactory : SkeletonItemFactory
{
    private HumanSkeletonSkeletonItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    public override string Name => "Human Skeleton";

    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "& Human Skeleton~";
    public override int LevelNormallyFound => 5;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 60;
    public override Item CreateItem() => new Item(Game, this);
}
