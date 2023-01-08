namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class FearTimedAction : TimedAction
    {
        public FearTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You are terrified!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel bolder now.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrAfraid);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
