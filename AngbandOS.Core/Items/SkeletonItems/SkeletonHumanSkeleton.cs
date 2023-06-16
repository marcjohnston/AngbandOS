namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SkeletonHumanSkeleton : SkeletonItemClass
{
    private SkeletonHumanSkeleton(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '~';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Human Skeleton";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "& Human Skeleton~";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int? SubCategory => 8;
    public override int Weight => 60;
    public override Item CreateItem() => new HumanSkeletonItem(SaveGame);
}
