using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ShotRoundedPebble : ShotItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Rounded Pebble";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Rounded Pebble~";
        public override bool ShowMods => true;
        public override int? SubCategory => 0;
        public override int Weight => 4;
    }
}
