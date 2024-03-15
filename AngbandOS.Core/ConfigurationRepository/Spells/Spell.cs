// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Spells;

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
        SpellDefinition definition = new()
        {
            Key = Key,
            CastScriptName = CastScriptName,
            CastFailedScriptName = CastFailedScriptName,
            Name = Name,
            LearnedDetails = LearnedDetails
        };
        return JsonSerializer.Serialize<SpellDefinition>(definition);
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;


    public void Bind()
    {
        CastScript = SaveGame.SingletonRepository.Scripts.BindNullable<ISpellScript, IScript>(CastScriptName);
        CastFailedScript = SaveGame.SingletonRepository.Scripts.BindNullable<ISpellScript, IScript>(CastFailedScriptName);
    }

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
    /// Returns the name of an ICancellableScript script to be run, when the spell is cast.
    /// </summary>
    protected virtual string? CastScriptName => null;
    protected virtual string? CastFailedScriptName => null;

    private Script? CastScript { get; set; }
    private Script? CastFailedScript { get; set; }

    private void ExecuteScript(Script? script)
    {
        switch (script)
        {
            case null:
                break;
            case ISpellScript asSpellScript:
                asSpellScript.ExecuteSpellScript(this);
                break;
            case IScript asScript:
                asScript.ExecuteScript();
                break;
            default:
                throw new Exception("Invalid script for spell.  Only ISpellScript and IScript scripts are supported for spells.");
        }
    }

    /// <summary>
    /// Performs the spell.
    /// </summary>
    public void CastSpell()
    {
        ExecuteScript(CastScript);
    }

    /// <summary>
    /// This event is thrown when a spell cast fails by chance. When a spell cast fails, a second roll is made with the same failure
    /// chance to determine if a failure cast should happen.
    /// </summary>
    public void CastFailed()
    {
        ExecuteScript(CastFailedScript);
    }

    /// <summary>
    /// Returns a percentage of failure chance for a character if the specified class when casting the specific spell.  This value
    /// will be in the range of 0-100.  100% means, the spell will fail every time.  0% means, the spell will never fail.
    /// </summary>
    /// <returns></returns>
    public int FailureChance() 
    {
        if (!SaveGame.CanCastSpells)
        {
            return 100;
        }
        int chance = ClassSpell.BaseFailure;
        chance -= 3 * (SaveGame.ExperienceLevel - ClassSpell.Level);
        chance -= 3 * (SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ClassSpell.ManaCost > SaveGame.Mana.Value)
        {
            chance += 5 * (ClassSpell.ManaCost - SaveGame.Mana.Value);
        }
        int minfail = SaveGame.AbilityScores[SaveGame.BaseCharacterClass.SpellStat].SpellMinFailChance;
        if (SaveGame.BaseCharacterClass.ID != CharacterClass.Priest && SaveGame.BaseCharacterClass.ID != CharacterClass.Druid &&
            SaveGame.BaseCharacterClass.ID != CharacterClass.Mage && SaveGame.BaseCharacterClass.ID != CharacterClass.HighMage &&
            SaveGame.BaseCharacterClass.ID != CharacterClass.Cultist)
        {
            if (minfail < 5)
            {
                minfail = 5;
            }
        }
        if ((SaveGame.BaseCharacterClass.ID == CharacterClass.Priest || SaveGame.BaseCharacterClass.ID == CharacterClass.Druid) && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Cultist && SaveGame.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (SaveGame.StunTimer.Value > 50)
        {
            chance += 25;
        }
        else if (SaveGame.StunTimer.Value != 0)
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
        ClassSpell = SaveGame.SingletonRepository.ClassSpells.Get($"{characterClass.Key}.{this.Key}");
        SpellIndex = spellIndex;
        BookItemFactory = bookItemFactory;
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