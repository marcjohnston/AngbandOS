namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class InfravisionTimedAction : TimedAction
    {
        public InfravisionTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("Your eyes begin to tingle!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("Your eyes stop tingling.");
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
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
