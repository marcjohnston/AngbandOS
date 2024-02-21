// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells;

//[Serializable]
//public class SpellDefinition : IPoco
//{
//    public virtual string Key { get; set; }

//    /// <summary>
//    /// Returns the name of the spell, as rendered to the SaveGame.
//    /// </summary>
//    public virtual string Name { get; set; }

//    public bool IsValid()
//    {
//        throw new NotImplementedException();
//    }
//}

[Serializable]
internal abstract class Spell : IGetKey<string>
{
    protected readonly SaveGame SaveGame;

    protected Spell(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public BookItemFactory BookItemFactory { get; private set; }

    /// <summary>
    /// Returns the index of the spell in the realm.  This index starts at 0 and increments by one for each spell.
    /// </summary>
    public int SpellIndex { get; private set; }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Returns true, if the spell has been forgotten because the players level dropped to low.  When true, Learned is set to false.
    /// </summary>
    public bool Forgotten;

    /// <summary>
    /// Returns true, if the spell has been learned.  Once a spell is learned, forgetting the spell returns this value to false and sets the Forgotten property
    /// to true.
    /// </summary>
    public bool Learned;

    /// <summary>
    /// Returns the name of the spell, as rendered to the SaveGame.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns true, if the spell has been attempted to be cast; false, otherwise.  Set to false, by default.  Set to true, the first time the player attempts to cast the
    /// spell; regardless of success or failure.
    /// </summary>
    public bool Tried { get; private set; } = false;

    public ClassSpell ClassSpell { get; private set; }

    /// <summary>
    /// Performs the spell.
    /// </summary>
    public abstract void Cast();

    public void CastSpell()
    {
        // Cast the specific spell.
        Cast();

        // Check to see if this is the first time the spell 
        if (!Tried)
        {
            Tried = true;
            SaveGame.GainExperience(ClassSpell.FirstCastExperience * ClassSpell.Level);
        }
    }

    /// <summary>
    /// This event is thrown when a spell cast fails by chance. When a spell cast fails, a second roll is made with the same failure
    /// chance to determine if a failure cast should happen.
    /// </summary>
    public virtual void CastFailed() { }

    /// <summary>
    /// Returns a percentage of failure chance for a character if the specified class when casting the specific spell.  This value
    /// will be in the range of 0-100.  100% means, the spell will fail every time.  0% means, the spell will never fail.
    /// </summary>
    /// <returns></returns>
    public int FailureChance() 
    {
        BaseCharacterClass baseCharacterClass = SaveGame.BaseCharacterClass;
        if (baseCharacterClass.SpellCastingType == null)
        {
            return 100;
        }
        int chance = ClassSpell.BaseFailure;
        chance -= 3 * (SaveGame.ExperienceLevel - ClassSpell.Level);
        chance -= 3 * (SaveGame.AbilityScores[baseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ClassSpell.ManaCost > SaveGame.Mana)
        {
            chance += 5 * (ClassSpell.ManaCost - SaveGame.Mana);
        }
        int minfail = SaveGame.AbilityScores[baseCharacterClass.SpellStat].SpellMinFailChance;
        if (baseCharacterClass.ID != CharacterClass.Priest && baseCharacterClass.ID != CharacterClass.Druid &&
            baseCharacterClass.ID != CharacterClass.Mage && baseCharacterClass.ID != CharacterClass.HighMage &&
            baseCharacterClass.ID != CharacterClass.Cultist)
        {
            if (minfail < 5)
            {
                minfail = 5;
            }
        }
        if ((baseCharacterClass.ID == CharacterClass.Priest || baseCharacterClass.ID == CharacterClass.Druid) && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (baseCharacterClass.ID == CharacterClass.Cultist && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (SaveGame.TimedStun.TurnsRemaining > 50)
        {
            chance += 25;
        }
        else if (SaveGame.TimedStun.TurnsRemaining != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    public void Initialize(BookItemFactory bookItemFactory, int spellIndex)
    {
        BaseCharacterClass characterClass = SaveGame.BaseCharacterClass;
        ClassSpell = SaveGame.SingletonRepository.ClassSpells.Get($"{characterClass.GetType().Name}.{this.GetType().Name}");
        SpellIndex = spellIndex;
        BookItemFactory = bookItemFactory;

        // Check to see if the first spell for the character needs to be lowered.
        if (ClassSpell.Level < SaveGame.SpellFirst)
        {
            SaveGame.SpellFirst = ClassSpell.Level;
        }
    }

    public string Title()
    {
        string info;
        if (Forgotten)
        {
            info = "forgotten";
        }
        else if (!Learned)
        {
            info = "unknown";
        }
        else
        {
            info = !Tried ? "untried" : LearnedDetails;
        }

        return ClassSpell.Level >= 99 ? "(illegible)" : $"{Name,-30} {ClassSpell.Level,3} {ClassSpell.ManaCost,4} {FailureChance(),3}% {info}";
    }

    /// <summary>
    /// Renders debugging details about the spell.  Should not be used in-game.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Name} ({ClassSpell.Level}, {ClassSpell.ManaCost}, {ClassSpell.BaseFailure}, {ClassSpell.FirstCastExperience})";
    }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    /// <returns></returns>
    protected virtual string LearnedDetails => "";
}