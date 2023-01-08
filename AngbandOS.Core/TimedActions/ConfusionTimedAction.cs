namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class ConfusionTimedAction : TimedAction
    {
        public ConfusionTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int v)
        {
            bool notice = false;
            v = v > 10000 ? 10000 : v < 0 ? 0 : v;
            if (v != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You are confused!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel less confused now.");
                    notice = true;
                }
            }
            _timer = v;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrConfused);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
