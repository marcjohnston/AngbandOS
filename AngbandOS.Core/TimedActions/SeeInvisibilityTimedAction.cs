namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class SeeInvisibilityTimedAction : TimedAction
    {
        public SeeInvisibilityTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("Your eyes feel very sensitive!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("Your eyes feel less sensitive.");
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
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
