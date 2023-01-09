namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class EtherealnessTimedAction : TimedAction
    {
        public EtherealnessTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You leave the physical world and turn into a wraith-being!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel opaque.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.RedrawMapFlaggedAction.Set();
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            SaveGame.Disturb(false);
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
