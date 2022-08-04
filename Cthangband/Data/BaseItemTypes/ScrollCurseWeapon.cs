using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollCurseWeapon : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Curse Weapon";

        public override int Chance1 => 1;
        public override string FriendlyName => "Curse Weapon";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 3;
        public override int Weight => 5;
    }
}
