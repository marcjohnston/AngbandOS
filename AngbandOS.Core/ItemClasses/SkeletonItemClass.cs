namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class SkeletonItemClass : ItemClass
    {
        public SkeletonItemClass(SaveGame saveGame) : base(saveGame) { }
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Skeleton;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Beige;
    }
}
