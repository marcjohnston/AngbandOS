using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingResistCold : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "Resist Cold";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Resist Cold";
        public override bool IgnoreCold => true;
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ResCold => true;
        public override int? SubCategory => 9;
        public override int Weight => 2;
    }
}