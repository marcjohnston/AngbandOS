namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SkeletonCanineSkeleton : SkeletonItemClass
{
    private SkeletonCanineSkeleton(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '~';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Canine Skeleton";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Canine Skeleton~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override int? SubCategory => 4;
    public override int Weight => 10;
    public override Item CreateItem() => new CanineSkeletonItem(SaveGame);
}
