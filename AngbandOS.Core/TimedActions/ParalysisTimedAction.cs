namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class ParalysisTimedAction : TimedAction
    {
        public ParalysisTimedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("You can move again.");
        }
        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("You are paralyzed!");
        }
        protected override void Noticed()
        {
            SaveGame.RedrawStateFlaggedAction.Set();
            base.Noticed();
        }
    }
}
