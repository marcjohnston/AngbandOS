using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollFire : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Fire";

        public override int Chance1 => 4;
        public override int Cost => 1000;
        public override string FriendlyName => "Fire";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 48;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.FireBall(new ProjectFire(eventArgs.SaveGame), 0, 150, 4);
            if (!(eventArgs.SaveGame.Player.TimedFireResistance != 0 || eventArgs.SaveGame.Player.HasFireResistance || eventArgs.SaveGame.Player.HasFireImmunity))
            {
                eventArgs.SaveGame.Player.TakeHit(50 + Program.Rng.DieRoll(50), "a Scroll of Fire");
            }
            eventArgs.Identified = true;
        }
    }
}
