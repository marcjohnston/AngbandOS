namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class SeeInvisibilityTimedAction : TimedAction
    {
        public SeeInvisibilityTimedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("Your eyes feel less sensitive.");
        }
        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("Your eyes feel very sensitive!");
        }
        protected override void Noticed()
        {
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            base.Noticed();
        }
    }
}
