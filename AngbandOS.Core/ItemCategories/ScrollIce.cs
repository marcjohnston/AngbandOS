namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollIce : ScrollItemClass
    {
        private ScrollIce(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Ice";

        public override int[] Chance => new int[] { 6, 0, 0, 0 };
        public override int Cost => 5000;
        public override string FriendlyName => "Ice";
        public override bool IgnoreCold => true;
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 49;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.FireBall(new IceProjectile(eventArgs.SaveGame), 0, 175, 4);
            if (!(eventArgs.SaveGame.Player.TimedColdResistance.TurnsRemaining != 0 || eventArgs.SaveGame.Player.HasColdResistance || eventArgs.SaveGame.Player.HasColdImmunity))
            {
                eventArgs.SaveGame.Player.TakeHit(100 + Program.Rng.DieRoll(100), "a Scroll of Ice");
            }
            eventArgs.Identified = true;
        }
    }
}
