// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CastingTypes;

/// <summary>
/// Represents basic spell casting properties.
/// </summary>
[Serializable]
internal class CastingType : IConfigurationRepository
{
    protected readonly SaveGame SaveGame;
    protected CastingType(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public virtual int Levels => SaveGame.ExperienceLevel;

    /// <summary>
    /// Returns the verb to use for casting.  Returns "cast" by default.  Divine casting type returns "recite".
    /// </summary>
    public virtual string CastVerb => "cast";

    /// <summary>
    /// Returns the noun to use for spells.  Returns "spell" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string SpellNoun => "spell";

    /// <summary>
    /// Returns the name for the magic type.  Returns "magic" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string MagicType => "magic";

    /// <summary>
    /// Returns true, if the casting type allows the player to choose which spell they want to learn.  Returns true, by default.  Divine
    /// spell casting returns false.
    /// </summary>
    public virtual bool CanChooseSpellToStudy => true;

    /// <summary>
    /// Returns true, if the casting type allows the player to use mana instead of consuming the item.  Returns false, by default.  Channeling
    /// casting type returns true.
    /// </summary>
    public virtual bool CanUseManaInsteadOfConsumingItem => false;

    public virtual string GetBookTitle(BookItem bookItem)
    {
        return $"{bookItem.RealmName} {Pluralize("Spellbook", bookItem.Count)}";
    }
    /// <summary>
    /// Cast a spell.  SaveGame.DoCast is called by default.  Mentalism casting type calls SaveGame.DoMentalism.
    /// </summary>
    public virtual void Cast()
    {
        string prayer = SaveGame.BaseCharacterClass.SpellCastingType.SpellNoun;
        if (!SaveGame.CanCastSpells)
        {
            SaveGame.MsgPrint("You cannot cast spells!");
            return;
        }
        if (SaveGame.TimedBlindness.TurnsRemaining != 0 || SaveGame.NoLight())
        {
            SaveGame.MsgPrint("You cannot see!");
            return;
        }
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            SaveGame.MsgPrint("You are too confused!");
            return;
        }
        if (!SaveGame.SelectItem(out Item? oPtr, "Use which book? ", false, true, true, new UsableSpellBookItemFilter(SaveGame)))
        {
            SaveGame.MsgPrint($"You have no {prayer} books!");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        BookItem bookItem = (BookItem)oPtr;
        SaveGame.HandleStuff();

        // Allow the player to select the spell.
        if (!SaveGame.GetSpell(out Spell? sPtr, SaveGame.BaseCharacterClass.SpellCastingType.CastVerb, bookItem, true))
        {
            SaveGame.MsgPrint($"You don't know any {prayer}s in that book.");
            return;
        }

        // Check to see if the user cancelled the selection.
        if (sPtr == null)
        {
            return;
        }

        if (sPtr.ManaCost > SaveGame.Mana)
        {
            string cast = SaveGame.BaseCharacterClass.SpellCastingType.CastVerb;
            SaveGame.MsgPrint($"You do not have enough mana to {cast} this {prayer}.");
            if (!SaveGame.GetCheck("Attempt it anyway? "))
            {
                return;
            }
        }
        int chance = sPtr.FailureChance();
        if (SaveGame.Rng.RandomLessThan(100) < chance)
        {
            SaveGame.MsgPrint($"You failed to get the {prayer} off!");
            sPtr.CastFailed();
        }
        else
        {
            sPtr.Cast();
            if (!sPtr.Worked)
            {
                int e = sPtr.FirstCastExperience;
                sPtr.Worked = true;
                SaveGame.GainExperience(e * sPtr.Level);
            }
        }
        SaveGame.EnergyUse = 100;
        if (sPtr.ManaCost <= SaveGame.Mana)
        {
            SaveGame.Mana -= sPtr.ManaCost;
        }
        else
        {
            int oops = sPtr.ManaCost - SaveGame.Mana;
            SaveGame.Mana = 0;
            SaveGame.FractionalMana = 0;
            SaveGame.MsgPrint("You faint from the effort!");
            SaveGame.TimedParalysis.AddTimer(SaveGame.Rng.DieRoll((5 * oops) + 1));
            if (SaveGame.Rng.RandomLessThan(100) < 50)
            {
                bool perm = SaveGame.Rng.RandomLessThan(100) < 25;
                SaveGame.MsgPrint("You have damaged your health!");
                SaveGame.DecreaseAbilityScore(Ability.Constitution, 15 + SaveGame.Rng.DieRoll(10), perm);
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get<RedrawManaFlaggedAction>().Set();
    }

    /// <summary>
    /// Returns true, if the spell weight of the armour can encumber movement.  Returns false, by default.  Arcane returns true.
    /// </summary>
    public virtual bool WeightEncumbersMovement => false;

    /// <summary>
    /// Returns true, if covered hands with gloves that are not of free-action, dexterity or typespecificvalue == 0 will restrict casting.  Returns false, by default.
    /// Arcane spell casting returns true.
    /// </summary>
    public virtual bool CoveredHandsRestrictCasting => false;
}
