using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandPolymorph : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Polymorph";

        public override int Chance1 => 1;
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Polymorph";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 13;
        public override int Weight => 10;
    }
}
