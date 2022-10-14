using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PolearmScytheofSlicing : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Red;
        public override string Name => "Polearm:Scythe of Slicing";

        public override int Chance1 => 4;
        public override int Cost => 3500;
        public override int Dd => 8;
        public override int Ds => 4;
        public override string FriendlyName => "& Scythe~ of Slicing";
        public override int Level => 60;
        public override int Locale1 => 60;
        public override bool ShowMods => true;
        public override int? SubCategory => 30;
        public override int Weight => 250;
    }
}
