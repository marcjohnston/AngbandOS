using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class CloakShadow : CloakItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.Black;
        public override string Name => "Cloak:Shadow Cloak";

        public override int Ac => 6;
        public override int Chance1 => 5;
        public override int Cost => 7500;
        public override string FriendlyName => "& Shadow Cloak~";
        public override int Level => 60;
        public override int Locale1 => 75;
        public override bool ResDark => true;
        public override bool ResLight => true;
        public override int? SubCategory => 6;
        public override int ToA => 4;
        public override int Weight => 5;
    }
}
