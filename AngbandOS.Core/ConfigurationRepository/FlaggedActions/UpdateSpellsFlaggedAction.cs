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
        string p = SaveGame.BaseCharacterClass.SpellNoun;
        if (!SaveGame.CanCastSpells)
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
        int numAllowed = SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].HalfSpellsPerLevel * SaveGame.HalfLevelsOfSpellcraft() / 2;

        // Count the number of spells that were learned.
        int numKnown = 0;

        List<Spell> spellList = new List<Spell>();
        if (SaveGame.PrimaryRealm != null)
        {
            foreach (BookItemFactory bookItemFactory in SaveGame.PrimaryRealm.SpellBooks)
            {
                spellList.AddRange(bookItemFactory.Spells);
            }
        }
        if (SaveGame.SecondaryRealm != null)
        {
            foreach (BookItemFactory bookItemFactory in SaveGame.SecondaryRealm.SpellBooks)
            {
                spellList.AddRange(bookItemFactory.Spells);
            }
        }
        foreach (Spell spell in spellList)
        {
            if (spell.Learned)
            {
                numKnown++;
            }
        }
        SaveGame.SpareSpellSlots.Value = numAllowed - numKnown;
        if (numKnown != 0)
        {
            // Enumerate the spells that were learned, to determine if the level of the player fell below the level of the spell.
            foreach (Spell spell in SaveGame.SpellOrder)
            {
                if (spell.ClassSpell.Level > SaveGame.ExperienceLevel.Value && spell.Learned)
                {
                    spell.Forgotten = true;
                    spell.Learned = false;
                    numKnown--;
                    SaveGame.MsgPrint($"You have forgotten the {p} of {spell.Name}.");
                    SaveGame.SpareSpellSlots.Value++;
                }
            }

            // Now check to see if there are too many spells learned and attempt to forget as many as needed.
            int forgetIndex = SaveGame.SpellOrder.Count - 1;
            while (SaveGame.SpareSpellSlots.Value < 0 && forgetIndex >= 0)
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
                SaveGame.SpareSpellSlots.Value++;
            }
        }

        // Count the number of spells that have been forgotten.
        int forgottenTotal = 0;
        foreach (Spell spell in spellList)
        {
            if (spell.Forgotten)
            {
                forgottenTotal++;
            }
        }

        // Check to see if we regain some forgotten spells.
        int spellOrderIndex = SaveGame.SpellOrder.Count - 1;
        while (SaveGame.SpareSpellSlots.Value > 0 && forgottenTotal > 0 && spellOrderIndex >= 0)
        {
            Spell spell = SaveGame.SpellOrder[spellOrderIndex];
            if (SaveGame.ExperienceLevel.Value >= spell.ClassSpell.Level && spell.Forgotten)
            {
                spell.Forgotten = false;
                spell.Learned = true;
                forgottenTotal--;
                if (!SaveGame.FullScreenOverlay)
                {
                    SaveGame.MsgPrint($"You have remembered the {p} of {spell.Name}.");
                }
                SaveGame.SpareSpellSlots.Value--;
            }
            spellOrderIndex--;
        }

        // Count of number of spare slots.
        int newSpareSpellSlots = 0;
        foreach (Spell spell in spellList)
        {
            // Check to see if the level of the spell is greater than where we are at.
            if (spell.ClassSpell.Level > SaveGame.ExperienceLevel.Value)
            {
                // Don't count this spell.
                continue;
            }

            // Check to see if we already learned it.
            if (spell.Learned)
            {
                // Don't count this spell.
                continue;
            }
            newSpareSpellSlots++;
        }

        // Check to see if we need to reduce the number of spare slots.
        if (SaveGame.SpareSpellSlots.Value > newSpareSpellSlots)
        {
            // Reduce the number of spare slots.
            SaveGame.SpareSpellSlots.Value = newSpareSpellSlots;
        }

        if (SaveGame.OldSpareSpellSlots != SaveGame.SpareSpellSlots.Value)
        {
            if (SaveGame.SpareSpellSlots.Value != 0)
            {
                if (!SaveGame.FullScreenOverlay)
                {
                    string suffix = SaveGame.SpareSpellSlots.Value != 1 ? "s" : "";
                    SaveGame.MsgPrint($"You can learn {SaveGame.SpareSpellSlots.Value} more {p}{suffix}.");
                }
            }
            SaveGame.OldSpareSpellSlots = SaveGame.SpareSpellSlots.Value;
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStudyFlaggedAction)).Set();
        }
    }
}
