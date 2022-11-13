using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSeeInvisible : RingItemClass
    {
        public override char Character => '=';
        public override string Name => "See Invisible";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 340;
        public override bool EasyKnow => true;
        public override string FriendlyName => "See Invisible";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override bool SeeInvis => true;
        public override int? SubCategory => 22;
        public override int Weight => 2;
    }
}
