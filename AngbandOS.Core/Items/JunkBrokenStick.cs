using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class JunkBrokenStick : JunkItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Red;
        public override string Name => "Broken Stick";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Stick~";
        public override int? SubCategory => 6;
        public override int Weight => 3;
    }
}