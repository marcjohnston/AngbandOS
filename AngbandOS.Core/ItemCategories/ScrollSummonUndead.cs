using AngbandOS.Core;
using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollSummonUndead : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Summon Undead";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Summon Undead";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int? SubCategory => 5;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            for (int i = 0; i < Program.Rng.DieRoll(3); i++)
            {
                if (eventArgs.SaveGame.Level.Monsters.SummonSpecific(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, eventArgs.SaveGame.Difficulty, Constants.SummonUndead))
                {
                    eventArgs.Identified = true;
                }
            }
        }
    }
}
