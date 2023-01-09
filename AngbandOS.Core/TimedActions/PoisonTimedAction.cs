namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class PoisonTimedAction : TimedAction
    {
        public PoisonTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override void ProcessWorld()
        {
            if (TimeRemaining != 0)
            {
                int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                SetTimer(TimeRemaining - adjust);
            }
        }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You are poisoned!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You are no longer poisoned.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.RedrawPoisonedFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
