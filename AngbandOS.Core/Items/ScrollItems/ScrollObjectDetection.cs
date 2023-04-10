namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollObjectDetection : ScrollItemClass
    {
        private ScrollObjectDetection(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Object Detection";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Object Detection";
        public override int? SubCategory => 27;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.DetectObjectsNormal())
            {
                eventArgs.Identified = true;
            }
        }
        public override Item CreateItem() => new ObjectDetectionScrollItem(SaveGame);
    }
}
