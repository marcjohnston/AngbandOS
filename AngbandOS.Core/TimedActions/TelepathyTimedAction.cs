namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class TelepathyTimedAction : TimedAction
    {
        public TelepathyTimedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("Your consciousness contracts again.");
        }
        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("You feel your consciousness expand!");
        }
        protected override void Noticed()
        {
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            base.Noticed();
        }
    }
}
