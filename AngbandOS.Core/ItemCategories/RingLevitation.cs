using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingLevitation : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Levitation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override bool EasyKnow => true;
        public override bool Feather => true;
        public override string FriendlyName => "Levitation";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 2;
    }
}