// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResearchSpellScript : Script, IScript, ICastSpellScript, IStoreCommandScript
{
    private ResearchSpellScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the research item script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the research item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string spellType = Game.CharacterClass.SpellNoun;
        // If we don't have a realm then we can't do anything
        if (!Game.CanCastSpells)
        {
            Game.MsgPrint("You cannot read books!");
            return;
        }
        // We can't learn spells if we're blind or confused
        if (Game.BlindnessTimer.Value != 0)
        {
            Game.MsgPrint("You cannot see!");
            return;
        }
        if (Game.ConfusionTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused!");
            return;
        }
        // We can only learn new spells if we have spare slots
        if (Game.SpareSpellSlots.IntValue == 0)
        {
            Game.MsgPrint($"You cannot learn any new {spellType}s!");
            return;
        }
        string plural = Game.SpareSpellSlots.IntValue == 1 ? "" : "s";
        Game.MsgPrint($"You can learn {Game.SpareSpellSlots.IntValue} new {spellType}{plural}.");
        Game.MsgPrint(string.Empty);
        // Get the spell books we have
        if (!Game.SelectItem(out Item? item, "Study which book? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(IsUsableSpellBookItemFilter))))
        {
            Game.MsgPrint("You have no books that you can read.");
            return;
        }
        // Check each book
        if (item == null)
        {
            return;
        }

        // Check that the book is useable by the player
        if (item.Spells == null)
        {
            Game.MsgPrint("You can't read that.");
            return;
        }
        Game.HandleStuff();

        // Arcane casters can choose their spell
        Spell? spell = null;
        if (Game.CharacterClass.CanChooseSpellToStudy)
        {
            // Allow the user to select a spell.
            if (!Game.GetSpell(out spell, "study", item, false))
            {
                // There are no spells.
                Game.MsgPrint($"You cannot learn any {spellType}s from that book.");
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

            // Gather the potential spells from the book
            foreach (Spell sPtr in item.Spells)
            {
                if (Game.SpellOkay(sPtr, false))
                {
                    k++;
                    if (Game.RandomLessThan(k) == 0)
                    {
                        spell = sPtr;
                    }
                }
            }
        }
        // If we failed to get a spell, return
        if (spell == null)
        {
            Game.MsgPrint($"You cannot learn any {spellType}s from that book.");
            return;
        }
        // Learning a spell takes a turn (although that's not very relevant)
        Game.EnergyUse = 100;
        // Mark the spell as learned
        spell.Learned = true;

        // Mark the spell as the last spell learned, in case we need to start forgetting them
        Game.SpellOrder.Add(spell);

        // Let the player know they've learned a spell
        Game.MsgPrint($"You have learned the {spellType} of {spell.Name}.");
        Game.PlaySound(SoundEffectEnum.Study);
        Game.SpareSpellSlots.IntValue--;
        if (Game.SpareSpellSlots.IntValue != 0)
        {
            plural = Game.SpareSpellSlots.IntValue != 1 ? "s" : "";
            Game.MsgPrint($"You can learn {Game.SpareSpellSlots.IntValue} more {spellType}{plural}.");
        }
        Game.OldSpareSpellSlots = Game.SpareSpellSlots.IntValue;
    }
}
