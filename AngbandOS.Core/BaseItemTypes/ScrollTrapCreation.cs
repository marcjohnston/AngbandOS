using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollTrapCreation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Trap Creation";

        public override int Chance1 => 1;
        public override string FriendlyName => "Trap Creation";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 7;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.TrapCreation())
            {
                eventArgs.Identified = true;
            }
        }
    }
}
