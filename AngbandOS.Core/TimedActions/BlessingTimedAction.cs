namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class BlessingTimedAction : TimedAction
    {
        public BlessingTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You feel righteous!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("The prayer has expired.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
