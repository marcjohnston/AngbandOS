namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class HasteTimedAction : TimedAction
    {
        public HasteTimedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("You feel yourself slow down.");
        }
        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("You feel yourself moving faster!");
        }
        protected override void Noticed()
        {
            SaveGame.UpdateBonusesFlaggedAction.Set();
            base.Noticed();
        }
    }
}
