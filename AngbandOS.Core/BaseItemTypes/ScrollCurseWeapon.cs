using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollCurseWeapon : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Curse Weapon";

        public override int Chance1 => 1;
        public override string FriendlyName => "Curse Weapon";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 3;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.CurseWeapon())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
