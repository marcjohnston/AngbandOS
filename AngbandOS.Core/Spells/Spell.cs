// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Spells;

[Serializable]
internal abstract class Spell : IGetKey
{
    protected readonly Game Game;

    protected Spell(Game game)
    {
        Game = game;
    }

    public ItemFactory SpellBookItemFactory { get; private set; }

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
        SpellGameConfiguration definition = new()
        {
            Key = Key,
            CastScriptName = CastScriptName,
            CastFailedScriptName = CastFailedScriptName,
            Name = Name,
            LearnedDetails = LearnedDetails
        };
        return JsonSerializer.Serialize<SpellGameConfiguration>(definition);
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;


    public virtual void Bind()
    {
        CastScript = Game.SingletonRepository.GetNullable<ICastScript>(CastScriptName);
        CastFailedScript = Game.SingletonRepository.GetNullable<ICastScript>(CastFailedScriptName);
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
    /// Returns the name of the spell, as rendered to the Game.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns true, if the spell has been attempted to be cast; false, otherwise.  Set to false, by default.  Set to true, the first time the player attempts to cast the
    /// spell; regardless of success or failure.
    /// </summary>
    public bool Tried { get; private set; } = false;

    public ClassSpell ClassSpell { get; private set; }

    /// <summary>
    /// Returns the name of an <see cref="ICastScript"/> or <see cref="IScript"/> script to be run, when the spell is cast; or null, if the spell does nothing when successfully casted.  This
    /// property is used to bind the <see cref="CastScript"/> property during the bind phase.
    /// </summary>
    protected virtual string? CastScriptName => null;

    /// <summary>
    /// Returns the name of an <see cref="ICastScript"/> or <see cref="IScript"/> script to be run, when the spell fails; or null, if the spell does nothing when the spell fails.  This
    /// property is used to bind the <see cref="CastFailedScript"/> property during the bind phase.
    /// </summary>
    protected virtual string? CastFailedScriptName => null;

    private ICastScript? CastScript { get; set; }
    private ICastScript? CastFailedScript { get; set; }

    private void ExecuteScript(ICastScript? script)
    {
        switch (script)
        {
            case null:
                break;
            case IScriptSpell asSpellScript:
                asSpellScript.ExecuteScriptSpell(this);
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
        if (!Game.CanCastSpells)
        {
            return 100;
        }
        int chance = ClassSpell.BaseFailure;
        chance -= 3 * (Game.ExperienceLevel.IntValue - ClassSpell.Level);
        chance -= 3 * (Game.AbilityScores[Game.BaseCharacterClass.SpellStat].SpellFailureReduction - 1);
        if (ClassSpell.ManaCost > Game.Mana.IntValue)
        {
            chance += 5 * (ClassSpell.ManaCost - Game.Mana.IntValue);
        }
        int minfail = Game.AbilityScores[Game.BaseCharacterClass.SpellStat].SpellMinFailChance;
        if (Game.BaseCharacterClass.ID != CharacterClass.Priest && Game.BaseCharacterClass.ID != CharacterClass.Druid &&
            Game.BaseCharacterClass.ID != CharacterClass.Mage && Game.BaseCharacterClass.ID != CharacterClass.HighMage &&
            Game.BaseCharacterClass.ID != CharacterClass.Cultist)
        {
            if (minfail < 5)
            {
                minfail = 5;
            }
        }
        if ((Game.BaseCharacterClass.ID == CharacterClass.Priest || Game.BaseCharacterClass.ID == CharacterClass.Druid) && Game.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (Game.BaseCharacterClass.ID == CharacterClass.Cultist && Game.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (chance < minfail)
        {
            chance = minfail;
        }
        if (Game.StunTimer.Value > 50)
        {
            chance += 25;
        }
        else if (Game.StunTimer.Value != 0)
        {
            chance += 15;
        }
        if (chance > 95)
        {
            chance = 95;
        }
        return chance;
    }

    public void Initialize(ItemFactory itemFactory, int spellIndex)
    {
        BaseCharacterClass characterClass = Game.BaseCharacterClass;
        ClassSpell = Game.SingletonRepository.Get<ClassSpell>($"{characterClass.Key}.{this.Key}");
        SpellIndex = spellIndex;
        SpellBookItemFactory = itemFactory;
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