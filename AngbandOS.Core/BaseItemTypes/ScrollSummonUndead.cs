using AngbandOS.Core;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSummonUndead : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Summon Undead";

        public override int Chance1 => 1;
        public override string FriendlyName => "Summon Undead";
        public override int Level => 15;
        public override int Locale1 => 15;
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
