namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrArmorRedrawAction : RedrawAction
    {
        public PrArmorRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void RedrawNow()
        {
            SaveGame.PrtAc();
        }
    }
}
