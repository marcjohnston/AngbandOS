namespace AngbandOS.Core.TimedActions
{
    [Serializable]
    internal class StunTimedAction : TimedAction
    {
        public StunTimedAction(SaveGame saveGame) : base(saveGame) { }
        public override void ProcessWorld()
        {
            if (TimeRemaining != 0)
            {
                int adjust = SaveGame.Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                SetTimer(TimeRemaining - adjust);
            }
        }
        public override bool SetTimer(int value)
        {
            int oldAux, newAux;
            bool notice = false;
            value = value > 10000 ? 10000 : value < 0 ? 0 : value;
            if (!SaveGame.Player.Race.CanBeStunned)
            {
                value = 0;
            }
            if (TimeRemaining > 100)
            {
                oldAux = 3;
            }
            else if (TimeRemaining > 50)
            {
                oldAux = 2;
            }
            else if (TimeRemaining > 0)
            {
                oldAux = 1;
            }
            else
            {
                oldAux = 0;
            }
            if (value > 100)
            {
                newAux = 3;
            }
            else if (value > 50)
            {
                newAux = 2;
            }
            else if (value > 0)
            {
                newAux = 1;
            }
            else
            {
                newAux = 0;
            }
            if (newAux > oldAux)
            {
                switch (newAux)
                {
                    case 1:
                        SaveGame.MsgPrint("You have been stunned.");
                        break;

                    case 2:
                        SaveGame.MsgPrint("You have been heavily stunned.");
                        break;

                    case 3:
                        SaveGame.MsgPrint("You have been knocked out.");
                        break;
                }
                if (Program.Rng.DieRoll(1000) < value || Program.Rng.DieRoll(16) == 1)
                {
                    SaveGame.MsgPrint("A vicious Attack hits your head.");
                    if (Program.Rng.DieRoll(3) == 1)
                    {
                        if (!SaveGame.Player.HasSustainIntelligence)
                        {
                            SaveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                        }
                        if (!SaveGame.Player.HasSustainWisdom)
                        {
                            SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                        }
                    }
                    else if (Program.Rng.DieRoll(2) == 1)
                    {
                        if (!SaveGame.Player.HasSustainIntelligence)
                        {
                            SaveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                        }
                    }
                    else
                    {
                        if (!SaveGame.Player.HasSustainWisdom)
                        {
                            SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                        }
                    }
                }
                notice = true;
            }
            else if (newAux < oldAux)
            {
                switch (newAux)
                {
                    case 0:
                        SaveGame.MsgPrint("You are no longer stunned.");
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
            SaveGame.UpdateBonusesFlaggedAction.Set();
            SaveGame.RedrawStunFlaggedAction.Set();
            SaveGame.HandleStuff();
            return true;
        }
    }
}
