using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollProtectionFromEvil : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Protection from Evil";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override string FriendlyName => "Protection from Evil";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 37;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            int i = 3 * eventArgs.SaveGame.Player.Level;
            if (eventArgs.SaveGame.Player.SetTimedProtectionFromEvil(eventArgs.SaveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + i))
            {
                eventArgs.Identified = true;
            }
        }
    }
}