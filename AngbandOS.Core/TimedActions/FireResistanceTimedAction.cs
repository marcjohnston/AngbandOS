namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class FireResistanceTimedAction : TimedAction
    {
        public FireResistanceTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You feel resistant to fire!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel less resistant to fire.");
                    notice = true;
                }
            }
            _timer = value;
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
