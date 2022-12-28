using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SkeletonBrokenBone : SkeletonItemClass
    {
        public SkeletonBrokenBone(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '~';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Broken Bone";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Bone~";
        public override int? SubCategory => 2;
        public override int Weight => 2;
    }
}
