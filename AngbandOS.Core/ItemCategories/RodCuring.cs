namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodCuring : RodItemClass
    {
        private RodCuring(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Curing";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 15000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Curing";
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override int? SubCategory => 8;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.Player.TimedBlindness.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TimedPoison.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TimedConfusion.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TimedStun.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TimedBleeding.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.Player.TimedHallucinations.SetTimer(0))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 999;
        }
    }
}
