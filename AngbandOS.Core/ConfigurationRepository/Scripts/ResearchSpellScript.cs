// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResearchSpellScript : Script, IScript, IStoreScript
{
    private ResearchSpellScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the research item script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the research item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string spellType = SaveGame.BaseCharacterClass.SpellCastingType.SpellNoun;
        // If we don't have a realm then we can't do anything
        if (!SaveGame.CanCastSpells)
        {
            SaveGame.MsgPrint("You cannot read books!");
            return;
        }
        // We can't learn spells if we're blind or confused
        if (SaveGame.BlindnessTimer.Value != 0)
        {
            SaveGame.MsgPrint("You cannot see!");
            return;
        }
        if (SaveGame.ConfusedTimer.Value != 0)
        {
            SaveGame.MsgPrint("You are too confused!");
            return;
        }
        // We can only learn new spells if we have spare slots
        if (SaveGame.SpareSpellSlots.Value == 0)
        {
            SaveGame.MsgPrint($"You cannot learn any new {spellType}s!");
            return;
        }
        string plural = SaveGame.SpareSpellSlots.Value == 1 ? "" : "s";
        SaveGame.MsgPrint($"You can learn {SaveGame.SpareSpellSlots.Value} new {spellType}{plural}.");
        SaveGame.MsgPrint(null);
        // Get the spell books we have
        if (!SaveGame.SelectItem(out Item? item, "Study which book? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(IsUsableSpellBookItemFilter))))
        {
            SaveGame.MsgPrint("You have no books that you can read.");
            return;
        }
        // Check each book
        if (item == null)
        {
            return;
        }
        SaveGame.HandleStuff();

        // Arcane casters can choose their spell
        Spell? spell = null;
        if (SaveGame.BaseCharacterClass.SpellCastingType.CanChooseSpellToStudy)
        {
            // Allow the user to select a spell.
            if (!SaveGame.GetSpell(out spell, "study", item, false))
            {
                // There are no spells.
                SaveGame.MsgPrint($"You cannot learn any {spellType}s from that book.");
                return;
            }

            // Check to see if the user cancelled the selection.
            if (spell == null)
            {
                return;
            }
        }
        else
        {
            // We need to choose a spell at random
            int k = 0;

            BookItemFactory bookItemFactory = (BookItemFactory)item.Factory;

            // Gather the potential spells from the book
            foreach (Spell sPtr in bookItemFactory.Spells)
            {
                if (SaveGame.SpellOkay(sPtr, false))
                {
                    k++;
                    if (SaveGame.RandomLessThan(k) == 0)
                    {
                        spell = sPtr;
                    }
                }
            }
        }
        // If we failed to get a spell, return
        if (spell == null)
        {
            SaveGame.MsgPrint($"You cannot learn any {spellType}s from that book.");
            return;
        }
        // Learning a spell takes a turn (although that's not very relevant)
        SaveGame.EnergyUse = 100;
        // Mark the spell as learned
        spell.Learned = true;

        // Mark the spell as the last spell learned, in case we need to start forgetting them
        SaveGame.SpellOrder.Add(spell);

        // Let the player know they've learned a spell
        SaveGame.MsgPrint($"You have learned the {spellType} of {spell.Name}.");
        SaveGame.PlaySound(SoundEffectEnum.Study);
        SaveGame.SpareSpellSlots.Value--;
        if (SaveGame.SpareSpellSlots.Value != 0)
        {
            plural = SaveGame.SpareSpellSlots.Value != 1 ? "s" : "";
            SaveGame.MsgPrint($"You can learn {SaveGame.SpareSpellSlots.Value} more {spellType}{plural}.");
        }
        SaveGame.OldSpareSpellSlots = SaveGame.SpareSpellSlots.Value;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStudyFlaggedAction)).Set();
    }
}
