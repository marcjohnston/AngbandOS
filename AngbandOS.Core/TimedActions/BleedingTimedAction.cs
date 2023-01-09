namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class BleedingTimedAction : TimedAction
    {
        public BleedingTimedAction(SaveGame saveGame) : base(saveGame) { }

        public override bool SetTimer(int value)
        {
            int currentBleedingRate;
            int newBleedingRate;
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (!SaveGame.Player.Race.CanBleed(SaveGame.Player.Level))
            {
                value = 0;
            }
            if (TimeRemaining > 1000)
            {
                currentBleedingRate = 7;
            }
            else if (TimeRemaining > 200)
            {
                currentBleedingRate = 6;
            }
            else if (TimeRemaining > 100)
            {
                currentBleedingRate = 5;
            }
            else if (TimeRemaining > 50)
            {
                currentBleedingRate = 4;
            }
            else if (TimeRemaining > 25)
            {
                currentBleedingRate = 3;
            }
            else if (TimeRemaining > 10)
            {
                currentBleedingRate = 2;
            }
            else if (TimeRemaining > 0)
            {
                currentBleedingRate = 1;
            }
            else
            {
                currentBleedingRate = 0;
            }
            if (value > 1000)
            {
                newBleedingRate = 7;
            }
            else if (value > 200)
            {
                newBleedingRate = 6;
            }
            else if (value > 100)
            {
                newBleedingRate = 5;
            }
            else if (value > 50)
            {
                newBleedingRate = 4;
            }
            else if (value > 25)
            {
                newBleedingRate = 3;
            }
            else if (value > 10)
            {
                newBleedingRate = 2;
            }
            else if (value > 0)
            {
                newBleedingRate = 1;
            }
            else
            {
                newBleedingRate = 0;
            }
            if (newBleedingRate > currentBleedingRate)
            {
                switch (newBleedingRate)
                {
                    case 1:
                        SaveGame.MsgPrint("You have been given a graze.");
                        break;

                    case 2:
                        SaveGame.MsgPrint("You have been given a light cut.");
                        break;

                    case 3:
                        SaveGame.MsgPrint("You have been given a bad cut.");
                        break;

                    case 4:
                        SaveGame.MsgPrint("You have been given a nasty cut.");
                        break;

                    case 5:
                        SaveGame.MsgPrint("You have been given a severe cut.");
                        break;

                    case 6:
                        SaveGame.MsgPrint("You have been given a deep gash.");
                        break;

                    case 7:
                        SaveGame.MsgPrint("You have been given a mortal wound.");
                        break;
                }
                notice = true;
                if (Program.Rng.DieRoll(1000) < value || Program.Rng.DieRoll(16) == 1)
                {
                    if (!SaveGame.Player.HasSustainCharisma)
                    {
                        SaveGame.MsgPrint("You have been horribly scarred.");
                        SaveGame.Player.TryDecreasingAbilityScore(Ability.Charisma);
                    }
                }
            }
            else if (newBleedingRate < currentBleedingRate)
            {
                switch (newBleedingRate)
                {
                    case 0:
                        SaveGame.MsgPrint("You are no longer bleeding.");
                        SaveGame.Disturb(false);
                        break;
                }
                notice = true;
            }
            _timer = value;
            if (!notice)
            {
                return false;
            }
            SaveGame.Disturb(false);
            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            SaveGame.RedrawCutFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }

        public override void ProcessWorld()
        {
            if (TimeRemaining > 0)
            {
                int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                if (TimeRemaining > 1000)
                {
                    adjust = 0;
                }
                SetTimer(TimeRemaining - adjust);
            }
        }
    }
}
