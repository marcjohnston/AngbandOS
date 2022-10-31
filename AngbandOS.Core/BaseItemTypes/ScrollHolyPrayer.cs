using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollHolyPrayer : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Holy Prayer";

        public override int Chance1 => 1;
        public override int Cost => 80;
        public override string FriendlyName => "Holy Prayer";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int? SubCategory => 35;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.SetTimedBlessing(eventArgs.SaveGame.Player.TimedBlessing + Program.Rng.DieRoll(48) + 24))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
