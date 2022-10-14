using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollProtectionFromEvil : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Protection from Evil";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override string FriendlyName => "Protection from Evil";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 37;
        public override int Weight => 5;
    }
}
