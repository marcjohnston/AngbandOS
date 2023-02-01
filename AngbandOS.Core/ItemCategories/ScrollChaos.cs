namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollChaos : ScrollItemClass
    {
        private ScrollChaos(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Chaos";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 10000;
        public override string FriendlyName => "Chaos";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 100;
        public override int[] Locale => new int[] { 100, 0, 0, 0 };
        public override int? SubCategory => 50;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.FireBall(new ProjectChaos(eventArgs.SaveGame), 0, 222, 4);
            if (!eventArgs.SaveGame.Player.HasChaosResistance)
            {
                eventArgs.SaveGame.Player.TakeHit(111 + Program.Rng.DieRoll(111), "a Scroll of Chaos");
            }
            eventArgs.Identified = true;
        }
    }
}
