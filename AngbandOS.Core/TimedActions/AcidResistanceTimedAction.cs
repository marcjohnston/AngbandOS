namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class AcidResistanceTimedAction : TimedAction
    {
        public AcidResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }

        protected override void EffectIncreased(int newRate, int currentRate)
        {
            SaveGame.MsgPrint("You feel resistant to acid!");
        }
        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("You feel less resistant to acid.");
        }
    }
}
