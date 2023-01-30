namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class ColdResistanceTimedAction : TimedAction
    {
        public ColdResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("You feel less resistant to cold.");
        }
        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("You feel resistant to cold!");
        }
    }
}
