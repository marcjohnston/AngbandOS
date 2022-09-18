using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BoltSeeker : BoltItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Bolt:Seeker Bolt";

        public override int Chance1 => 4;
        public override int Cost => 25;
        public override int Dd => 4;
        public override int Ds => 5;
        public override string FriendlyName => "& Seeker Bolt~";
        public override int Level => 65;
        public override int Locale1 => 65;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int Weight => 3;
    }
}
