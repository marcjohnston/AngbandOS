using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSummonMonster : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Summon Monster";

        public override int Chance1 => 1;
        public override string FriendlyName => "Summon Monster";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => 4;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            for (int i = 0; i < Program.Rng.DieRoll(3); i++)
            {
                if (eventArgs.SaveGame.Level.Monsters.SummonSpecific(eventArgs.SaveGame.Player.MapY, eventArgs.SaveGame.Player.MapX, eventArgs.SaveGame.Difficulty, 0))
                {
                    eventArgs.Identified = true;
                }
            }
        }
    }
}
