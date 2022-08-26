using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PolearmHalberd : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Halberd";

        public override int Chance1 => 1;
        public override int Cost => 430;
        public override int Dd => 3;
        public override int Ds => 5;
        public override string FriendlyName => "& Halberd~";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override bool ShowMods => true;
        public override int SubCategory => 15;
        public override int Weight => 190;
    }
}
