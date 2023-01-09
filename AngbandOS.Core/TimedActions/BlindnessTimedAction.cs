namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class BlindnessTimedAction : TimedAction
    {
        public BlindnessTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You are blind!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You can see again.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.UpdateRemoveLightFlaggedAction.Set();
            SaveGame.UpdateRemoveViewFlaggedAction.Set();
            SaveGame.UpdateLightFlaggedAction.Set();
            SaveGame.UpdateViewFlaggedAction.Set();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.RedrawMapFlaggedAction.Set();
            SaveGame.RedrawBlindFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
