namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class TelepathyTimedAction : TimedAction
    {
        public TelepathyTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You feel your consciousness expand!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("Your consciousness contracts again.");
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
