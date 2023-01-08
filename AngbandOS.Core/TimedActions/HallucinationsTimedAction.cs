namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class HallucinationsTimedAction : TimedAction
    {
        public HallucinationsTimedAction(SaveGame saveGame) : base(saveGame) { }

        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("Oh, wow! Everything looks so cosmic now!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You can see clearly again.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
