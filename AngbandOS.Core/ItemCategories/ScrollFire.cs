using AngbandOS.Core.EventArgs;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Projection;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollFire : ScrollItemClass
    {
        public ScrollFire(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '?';
        public override string Name => "Fire";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 1000;
        public override string FriendlyName => "Fire";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
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
