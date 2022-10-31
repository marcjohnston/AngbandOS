using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDarkness : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Darkness";

        public override int Chance1 => 1;
        public override string FriendlyName => "Darkness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => 0;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.Player.HasBlindnessResistance && !eventArgs.SaveGame.Player.HasDarkResistance)
            {
                eventArgs.SaveGame.Player.SetTimedBlindness(eventArgs.SaveGame.Player.TimedBlindness + 3 + Program.Rng.DieRoll(5));
            }
            if (eventArgs.SaveGame.UnlightArea(10, 3))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
