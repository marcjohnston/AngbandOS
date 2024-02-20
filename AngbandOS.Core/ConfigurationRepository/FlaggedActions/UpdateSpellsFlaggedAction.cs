// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

/// <summary>
/// Represents a flagged action where the known spells are maintained.  The following processes are handled here:
/// 1. Ensures the number of learned spells (numKnown) does not exceed the maximum number of spells that is allowed (numAllowed).
/// 2. Forgets spells when the players level drops below the minimum level needed.
/// 3. Relearns spells when the players level returns to the minimum level needed.
/// Implements the <see cref="AngbandOS.Core.FlaggedActions.FlaggedAction" />
/// </summary>
/// <seealso cref="AngbandOS.Core.FlaggedActions.FlaggedAction" />
[Serializable]
internal class UpdateSpellsFlaggedAction : FlaggedAction
{
    private UpdateSpellsFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        int j;
        Spell sPtr;
        if (SaveGame.IsDead)
        {
            return;
        }
        string p = SaveGame.BaseCharacterClass.SpellCastingType.SpellNoun;
        if (SaveGame.BaseCharacterClass.SpellCastingType == null)
        {
            return;
        }
        if (!SaveGame.CanCastSpells)
        {
            return;
        }
        if (SaveGame.CharacterXtra)
        {
            return;
        }
        int levels = SaveGame.ExperienceLevel - SaveGame.SpellFirst + 1; // TODO: This should be moved to an action so that CharacterXtra isn't needed
        if (levels < 0)
        {
            levels = 0;
        }
        int numAllowed = SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].HalfSpellsPerLevel * levels / 2;

        // Count the number of spells that were learned.
        int numKnown = 0;
        
        foreach (Spell[] bookset in SaveGame.Spells)
        {
            foreach (Spell spell in bookset)
            {
                if (spell.Learned)
                {
                    numKnown++;
                }
            }
        }
        SaveGame.SpareSpellSlots = numAllowed - numKnown;
        if (numKnown != 0)
        {
            // Enumerate the spells that were learned, to determine if the level of the player fell below the level of the spell.
            foreach (Spell spell in SaveGame.SpellOrder)
            {
                if (spell.ClassSpell.Level > SaveGame.ExperienceLevel && spell.Learned)
                {
                    spell.Forgotten = true;
                    spell.Learned = false;
                    numKnown--;
                    SaveGame.MsgPrint($"You have forgotten the {p} of {spell.Name}.");
                    SaveGame.SpareSpellSlots++;
                }
            }

            // Now check to see if there are too many spells learned and attempt to forget as many as needed.
            int forgetIndex = SaveGame.SpellOrder.Count - 1;
            while (SaveGame.SpareSpellSlots < 0 && forgetIndex >= 0)
            {
                Spell spell = SaveGame.SpellOrder[forgetIndex];
                if (!spell.Learned)
                {
                    continue;
                }
                spell.Forgotten = true;
                spell.Learned = false;
                numKnown--;
                SaveGame.MsgPrint($"You have forgotten the {p} of {spell.Name}.");
                SaveGame.SpareSpellSlots++;
            }
        }

        // Count the number of spells that have been forgotten.
        int forgottenTotal = 0;
        foreach (Spell[] bookset in SaveGame.Spells)
        {
            foreach (Spell spell in bookset)
            {
                if (spell.Forgotten)
                {
                    forgottenTotal++;
                }
            }
        }

        // Check to see if we regain some forgotten spells.
        int spellOrderIndex = SaveGame.SpellOrder.Count - 1;
        while (SaveGame.SpareSpellSlots > 0 && forgottenTotal > 0 && spellOrderIndex >= 0)
        {
            Spell spell = SaveGame.SpellOrder[spellOrderIndex];
            if (SaveGame.ExperienceLevel >= spell.ClassSpell.Level && spell.Forgotten)
            {
                spell.Forgotten = false;
                spell.Learned = true;
                forgottenTotal--;
                if (!SaveGame.FullScreenOverlay)
                {
                    SaveGame.MsgPrint($"You have remembered the {p} of {spell.Name}.");
                }
                SaveGame.SpareSpellSlots--;
            }
            spellOrderIndex--;
        }

        // TODO: The number of spells remaining needs to be refactored to support the List<> and not 32/64
        int k = 0;
        int limit = SaveGame.SecondaryRealm == null ? 32 : 64;
        for (j = 0; j < limit; j++)
        {
            sPtr = SaveGame.Spells[j / 32][j % 32];
            if (sPtr.ClassSpell.Level > SaveGame.ExperienceLevel)
            {
                continue;
            }
            if (sPtr.Learned)
            {
                continue;
            }
            k++;
        }
        if (SaveGame.SecondaryRealm == null)
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
        if (SaveGame.SpareSpellSlots > k)
        {
            SaveGame.SpareSpellSlots = k;
        }
        if (SaveGame.OldSpareSpellSlots != SaveGame.SpareSpellSlots)
        {
            if (SaveGame.SpareSpellSlots != 0)
            {
                if (!SaveGame.FullScreenOverlay)
                {
                    string suffix = SaveGame.SpareSpellSlots != 1 ? "s" : "";
                    SaveGame.MsgPrint($"You can learn {SaveGame.SpareSpellSlots} more {p}{suffix}.");
                }
            }
            SaveGame.OldSpareSpellSlots = SaveGame.SpareSpellSlots;
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStudyFlaggedAction)).Set();
        }
    }
}
