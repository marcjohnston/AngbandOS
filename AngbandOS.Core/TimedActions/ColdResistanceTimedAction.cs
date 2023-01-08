namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class ColdResistanceTimedAction : TimedAction
    {
        public ColdResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int v)
        {
            bool notice = false;
            v = v > 10000 ? 10000 : v < 0 ? 0 : v;
            if (v != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You feel resistant to cold!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel less resistant to cold.");
                    notice = true;
                }
            }
            _timer = v;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
