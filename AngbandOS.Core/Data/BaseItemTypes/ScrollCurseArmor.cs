using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollCurseArmor : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Curse Armor";

        public override int Chance1 => 1;
        public override string FriendlyName => "Curse Armor";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 2;
        public override int Weight => 5;
    }
}
