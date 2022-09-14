using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowSling : BowItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Bow:Sling";

        public override int Chance1 => 1;
        public override int Cost => 5;
        public override string FriendlyName => "& Sling~";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int Weight => 5;
    }
}
