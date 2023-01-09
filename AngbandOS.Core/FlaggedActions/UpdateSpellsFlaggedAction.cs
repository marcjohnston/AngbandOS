namespace AngbandOS.Core.FlaggedActions
{
    [Serializable]
    internal class UpdateSpellsFlaggedAction : FlaggedAction
    {
        public UpdateSpellsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
        protected override void Execute()
        {
            int i, j;
            Spell sPtr;
            if (SaveGame.Player == null)
            {
                return;
            }
            string p = SaveGame.Player.Spellcasting.Type == CastingType.Arcane ? "spell" : "prayer";
            if (SaveGame.Player.Spellcasting.Type == CastingType.None)
            {
                return;
            }
            if (SaveGame.Player.Realm1 == Realm.None)
            {
                return;
            }
            if (SaveGame.CharacterXtra)
            {
                return;
            }
            int levels = SaveGame.Player.Level - SaveGame.Player.Spellcasting.SpellFirst + 1; // TODO: This should be moved to an action so that CharacterXtra isn't needed
            if (levels < 0)
            {
                levels = 0;
            }
            int numAllowed = SaveGame.Player.AbilityScores[SaveGame.Player.Spellcasting.SpellStat].HalfSpellsPerLevel * levels / 2;
            int numKnown = 0;
            for (j = 0; j < 64; j++)
            {
                if (SaveGame.Player.Spellcasting.Spells[j / 32][j % 32].Learned)
                {
                    numKnown++;
                }
            }
            SaveGame.Player.SpareSpellSlots = numAllowed - numKnown;
            for (i = 63; i >= 0; i--)
            {
                if (numKnown == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    continue;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level <= SaveGame.Player.Level)
                {
                    continue;
                }
                if (!sPtr.Learned)
                {
                    continue;
                }
                sPtr.Forgotten = true;
                sPtr.Learned = false;
                numKnown--;
                SaveGame.MsgPrint($"You have forgotten the {p} of {sPtr.Name}.");
                SaveGame.Player.SpareSpellSlots++;
            }
            for (i = 63; i >= 0; i--)
            {
                if (SaveGame.Player.SpareSpellSlots >= 0)
                {
                    break;
                }
                if (numKnown == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    continue;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (!sPtr.Learned)
                {
                    continue;
                }
                sPtr.Forgotten = true;
                sPtr.Learned = false;
                numKnown--;
                SaveGame.MsgPrint($"You have forgotten the {p} of {sPtr.Name}.");
                SaveGame.Player.SpareSpellSlots++;
            }
            int forgottenTotal = 0;
            for (int l = 0; l < 64; l++)
            {
                if (SaveGame.Player.Spellcasting.Spells[l / 32][l % 32].Forgotten)
                {
                    forgottenTotal++;
                }
            }
            for (i = 0; i < 64; i++)
            {
                if (SaveGame.Player.SpareSpellSlots <= 0)
                {
                    break;
                }
                if (forgottenTotal == 0)
                {
                    break;
                }
                j = SaveGame.Player.Spellcasting.SpellOrder[i];
                if (j >= 99)
                {
                    break;
                }
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level > SaveGame.Player.Level)
                {
                    continue;
                }
                if (!sPtr.Forgotten)
                {
                    continue;
                }
                sPtr.Forgotten = false;
                sPtr.Learned = true;
                forgottenTotal--;
                if (!SaveGame.FullScreenOverlay)
                {
                    SaveGame.MsgPrint($"You have remembered the {p} of {sPtr.Name}.");
                }
                SaveGame.Player.SpareSpellSlots--;
            }
            int k = 0;
            int limit = SaveGame.Player.Realm2 == Realm.None ? 32 : 64;
            for (j = 0; j < limit; j++)
            {
                sPtr = SaveGame.Player.Spellcasting.Spells[j / 32][j % 32];
                if (sPtr.Level > SaveGame.Player.Level)
                {
                    continue;
                }
                if (sPtr.Learned)
                {
                    continue;
                }
                k++;
            }
            if (SaveGame.Player.Realm2 == 0)
            {
                if (k > 32)
                {
                    k = 32;
                }
            }
            else
            {
                if (k > 64)
                {
                    k = 64;
                }
            }
            if (SaveGame.Player.SpareSpellSlots > k)
            {
                SaveGame.Player.SpareSpellSlots = k;
            }
            if (SaveGame.Player.OldSpareSpellSlots != SaveGame.Player.SpareSpellSlots)
            {
                if (SaveGame.Player.SpareSpellSlots != 0)
                {
                    if (!SaveGame.FullScreenOverlay)
                    {
                        string suffix = SaveGame.Player.SpareSpellSlots != 1 ? "s" : "";
                        SaveGame.MsgPrint($"You can learn {SaveGame.Player.SpareSpellSlots} more {p}{suffix}.");
                    }
                }
                SaveGame.Player.OldSpareSpellSlots = SaveGame.Player.SpareSpellSlots;
                SaveGame.RedrawStudyFlaggedAction.Set();
            }
        }
    }
}
