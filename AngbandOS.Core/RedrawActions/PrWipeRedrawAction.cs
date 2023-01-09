
namespace AngbandOS.Core.RedrawActions
{
    [Serializable]
    internal class PrWipeRedrawAction : RedrawAction
    {
        public PrWipeRedrawAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Draw()
        {
            SaveGame.MsgPrint(null);
            SaveGame.Clear();
        }
    }
}
