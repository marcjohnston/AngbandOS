using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class Cloak : CloakItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.Green;
        public override string Name => "Cloak:Cloak";

        public override int Ac => 1;
        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 3;
        public override string FriendlyName => "& Cloak~";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Locale2 => 20;
        public override int SubCategory => 1;
        public override int Weight => 10;
    }
}
