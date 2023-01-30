namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class BleedingTimedAction : TimedAction
    {
        public BleedingTimedAction(SaveGame saveGame) : base(saveGame) { }

        protected override int GetRate(int value)
        {
            if (value > 1000)
            {
                return 7;
            }
            else if (value > 200)
            {
                return 6;
            }
            else if (value > 100)
            {
                return 5;
            }
            else if (value > 50)
            {
                return 4;
            }
            else if (value > 25)
            {
                return 3;
            }
            else if (value > 10)
            {
                return 2;
            }
            else if (value > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        protected override void EffectIncreased(int newRate, int oldRate)
        {
            if (Program.Rng.DieRoll(1000) < newRate || Program.Rng.DieRoll(16) == 1)
            {
                if (!SaveGame.Player.HasSustainCharisma)
                {
                    SaveGame.MsgPrint("You have been horribly scarred.");
                    SaveGame.Player.TryDecreasingAbilityScore(Ability.Charisma);
                }
            }
            switch (newRate)
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
                default:
                    throw new Exception("Invalid rate for EffectStarted.");
            }
        }

        protected override void EffectStopped()
        {
            SaveGame.MsgPrint("You are no longer bleeding.");
        }

        protected override void Noticed()
        {
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.RedrawCutFlaggedAction.Set();
            base.Noticed();
        }

        public override bool SetTimer(int value)
        {
            if (!SaveGame.Player.Race.CanBleed(SaveGame.Player.Level))
            {
                value = 0;
            }
            return base.SetTimer(value);
        }

        /// <summary>
        /// Processes the timed bleeding.  A mortal wound (time remaining > 1000) will not heal over time.
        /// </summary>
        public override void ProcessWorld()
        {
            if (TurnsRemaining > 0)
            {
                int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                if (TurnsRemaining > 1000)
                {
                    adjust = 0;
                }
                AddTimer(-adjust);
            }
        }
    }
}
