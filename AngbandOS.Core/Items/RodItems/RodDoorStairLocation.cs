namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodDoorStairLocation : RodItemFactory
    {
        private RodDoorStairLocation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Door/Stair Location";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Door/Stair Location";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 15;

        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.DetectDoors())
            {
                zapRodEvent.Identified = true;
            }
            if (SaveGame.DetectStairs())
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 70;
        }
        public override Item CreateItem() => new DoorStairLocationRodItem(SaveGame);
    }
}
