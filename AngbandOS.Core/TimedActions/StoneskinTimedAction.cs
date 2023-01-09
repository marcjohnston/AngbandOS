namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class StoneskinTimedAction : TimedAction
    {
        public StoneskinTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("Your skin turns to stone.");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("Your skin returns to normal.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
