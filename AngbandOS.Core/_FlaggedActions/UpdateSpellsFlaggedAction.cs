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
    private UpdateSpellsFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        if (Game.IsDead)
        {
            return;
        }
        string p = Game.CharacterClass.SpellNoun;
        if (!Game.CanCastSpells)
        {
            return;
        }
        if (!Game.CanCastSpells)
        {
            return;
        }
        if (Game.CharacterXtra)
        {
            return;
        }
        int numAllowed = Game.CharacterClass.SpellStat.HalfSpellsPerLevel * Game.HalfLevelsOfSpellcraft() / 2;

        // Count the number of spells that were learned.
        int numKnown = 0;

        List<Spell> spellList = new List<Spell>();
        if (Game.PrimaryRealm != null)
        {
            foreach (ItemFactory itemFactory in Game.PrimaryRealm.SpellBooks)
            {
                spellList.AddRange(itemFactory.Spells);
            }
        }
        if (Game.SecondaryRealm != null)
        {
            foreach (ItemFactory itemFactory in Game.SecondaryRealm.SpellBooks)
            {
                spellList.AddRange(itemFactory.Spells);
            }
        }
        foreach (Spell spell in spellList)
        {
            if (spell.Learned)
            {
                numKnown++;
            }
        }
        Game.SpareSpellSlots.IntValue = numAllowed - numKnown;
        if (numKnown != 0)
        {
            // Enumerate the spells that were learned, to determine if the level of the player fell below the level of the spell.
            foreach (Spell spell in Game.SpellOrder)
            {
                if (spell.CharacterClassSpell.Level > Game.ExperienceLevel.IntValue && spell.Learned)
                {
                    spell.Forgotten = true;
                    spell.Learned = false;
                    numKnown--;
                    Game.MsgPrint($"You have forgotten the {p} of {spell.Name}.");
                    Game.SpareSpellSlots.IntValue++;
                }
            }

            // Now check to see if there are too many spells learned and attempt to forget as many as needed.
            int forgetIndex = Game.SpellOrder.Count - 1;
            while (Game.SpareSpellSlots.IntValue < 0 && forgetIndex >= 0)
            {
                Spell spell = Game.SpellOrder[forgetIndex];
                if (!spell.Learned)
                {
                    continue;
                }
                spell.Forgotten = true;
                spell.Learned = false;
                numKnown--;
                Game.MsgPrint($"You have forgotten the {p} of {spell.Name}.");
                Game.SpareSpellSlots.IntValue++;
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
        int spellOrderIndex = Game.SpellOrder.Count - 1;
        while (Game.SpareSpellSlots.IntValue > 0 && forgottenTotal > 0 && spellOrderIndex >= 0)
        {
            Spell spell = Game.SpellOrder[spellOrderIndex];
            if (Game.ExperienceLevel.IntValue >= spell.CharacterClassSpell.Level && spell.Forgotten)
            {
                spell.Forgotten = false;
                spell.Learned = true;
                forgottenTotal--;
                if (!Game.FullScreenOverlay)
                {
                    Game.MsgPrint($"You have remembered the {p} of {spell.Name}.");
                }
                Game.SpareSpellSlots.IntValue--;
            }
            spellOrderIndex--;
        }

        // Count of number of spare slots.
        int newSpareSpellSlots = 0;
        foreach (Spell spell in spellList)
        {
            // Check to see if the level of the spell is greater than where we are at.
            if (spell.CharacterClassSpell.Level > Game.ExperienceLevel.IntValue)
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
        if (Game.SpareSpellSlots.IntValue > newSpareSpellSlots)
        {
            // Reduce the number of spare slots.
            Game.SpareSpellSlots.IntValue = newSpareSpellSlots;
        }

        if (Game.OldSpareSpellSlots != Game.SpareSpellSlots.IntValue)
        {
            if (Game.SpareSpellSlots.IntValue != 0)
            {
                if (!Game.FullScreenOverlay)
                {
                    string suffix = Game.SpareSpellSlots.IntValue != 1 ? "s" : "";
                    Game.MsgPrint($"You can learn {Game.SpareSpellSlots.IntValue} more {p}{suffix}.");
                }
            }
            Game.OldSpareSpellSlots = Game.SpareSpellSlots.IntValue;
        }
    }
}
