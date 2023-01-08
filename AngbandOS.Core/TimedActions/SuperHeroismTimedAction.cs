namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class SuperHeroismTimedAction : TimedAction
    {
        public SuperHeroismTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override bool SetTimer(int value)
        {
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (value != 0)
            {
                if (TimeRemaining == 0)
                {
                    SaveGame.MsgPrint("You feel like a killing machine!");
                    notice = true;
                }
            }
            else
            {
                if (TimeRemaining != 0)
                {
                    SaveGame.MsgPrint("You feel less Berserk.");
                    notice = true;
                }
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateHealth);
            SaveGame.HandleStuff();
            return true;
        }
    }
}
