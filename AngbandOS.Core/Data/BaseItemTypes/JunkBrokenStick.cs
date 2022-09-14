using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class JunkBrokenStick : JunkItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Red;
        public override string Name => "Junk:Broken Stick";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Stick~";
        public override int SubCategory => 6;
        public override int Weight => 3;
    }
}
