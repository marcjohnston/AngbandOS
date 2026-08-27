// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal sealed class Spell : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }

    public Spell(Game game, SpellGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Name = gameConfiguration.Name;
        LearnedDetails = gameConfiguration.LearnedDetails;
    }

    private ItemFactory? _spellBookItemFactory = null;
    public ItemFactory? SpellBookItemFactory => _spellBookItemFactory;

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(Forgotten), saveGameState.CreateGameStateBag(Forgotten, Learned, Tried)),
            (nameof(_spellIndex), saveGameState.CreateGameStateBag(_spellIndex)),
            (nameof(_spellBookItemFactory), saveGameState.CreateDerivedGameStateBag(_spellBookItemFactory, typeof(ItemFactory))),
            (nameof(_characterClassSpell), saveGameState.CreateDerivedGameStateBag(_characterClassSpell, typeof(CharacterClassSpell)))
        );
    }

    private int _spellIndex = 0;

    /// <summary>
    /// Returns the index of the spell in the realm.  This index starts at 0 and increments by one for each spell.
    /// </summary>
    public int SpellIndex => _spellIndex;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        SpellGameConfiguration definition = new()
        {
            Key = Key,
            Name = Name,
            LearnedDetails = LearnedDetails
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string Key { get; }

    public string GetKey => Key;


    public void Bind(RestoreGameState? restoreGameState)
    {
        if (restoreGameState is not null)
        {
            (Forgotten, Learned, Tried) = restoreGameState.GetByKey(nameof(Forgotten)).Get3Bools();
            _spellIndex = restoreGameState.GetByKey(nameof(_spellIndex)).GetInt();
            _spellBookItemFactory = restoreGameState.GetByKey(nameof(_spellBookItemFactory)).GetDerivedReferenceOrDefault<ItemFactory>();
            _characterClassSpell = restoreGameState.GetByKey(nameof(_characterClassSpell)).GetDerivedReferenceOrDefault<CharacterClassSpell>();
        }
    }

    #region State Data
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
    /// Returns true, if the spell has been attempted to be cast; false, otherwise.  Set to false, by default.  Set to true, the first time the player attempts to cast the
    /// spell; regardless of success or failure.
    /// </summary>
    public bool Tried = false;
    #endregion

    /// <summary>
    /// Returns the name of the spell, as rendered to the Game.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// This is a field because it is state data.
    /// </remarks>
    private CharacterClassSpell? _characterClassSpell = null;

    /// <remarks>
    /// This is initialized after the player selects a character class.
    /// </remarks>
    public CharacterClassSpell? CharacterClassSpell => _characterClassSpell;
  
    /// <summary>
    /// Returns the spell scripts that are associated with either the success or failure of casting a spell.  This is done by performing a lookup through the spell script
    /// mapping repository.
    /// </summary>
    /// <param name="namespaceKey"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public MappedSpellScript GetMappedSpellScripts(bool successScript)
    {
        return Game.GetMappedSpellScript(this, SpellBookItemFactory.Realm, Game.CharacterClass, Game.ExperienceLevel.IntValue, successScript);
    }

    /// <summary>
    /// Performs the spell.
    /// </summary>
    public void CastSpell()
    {
        MappedSpellScript mappedSpellScript = GetMappedSpellScripts(true);
        ICastSpellScript[]? castSpellScripts = mappedSpellScript.CastSpellScripts;
        ExecuteSpellScripts(castSpellScripts);
    }

    /// <summary>
    /// This event is thrown when a spell cast fails by chance. When a spell cast fails, a second roll is made with the same failure
    /// chance to determine if a failure cast should happen.
    /// </summary>
    public void CastFailed()
    {
        MappedSpellScript mappedSpellScript = GetMappedSpellScripts(false);
        ICastSpellScript[]? castSpellScripts = mappedSpellScript.CastSpellScripts;
        ExecuteSpellScripts(castSpellScripts);
    }

    private void ExecuteSpellScripts(ICastSpellScript[]? spellScripts)
    {
        if (spellScripts != null)
        {
            foreach (ICastSpellScript spellScript in spellScripts)
            {
                spellScript.ExecuteCastSpellScript(this);
            }
        }
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
        int chance = CharacterClassSpell.BaseFailure;
        chance -= 3 * (Game.ExperienceLevel.IntValue - CharacterClassSpell.Level);
        chance -= 3 * (Game.CharacterClass.SpellAbility.SpellFailureReduction - 1);
        if (CharacterClassSpell.ManaCost > Game.Mana.IntValue)
        {
            chance += 5 * (CharacterClassSpell.ManaCost - Game.Mana.IntValue);
        }
        int minfail = Game.CharacterClass.SpellAbility.SpellMinFailChance;
        int characterClassMinimumSpellFailureChance = Game.CharacterClass.SpellMinFailChance ?? 0;
        if (minfail < characterClassMinimumSpellFailureChance)
        {
            minfail = characterClassMinimumSpellFailureChance;
        }
        if (Game.Bonuses.HasUnpriestlyWeapon)
        {
            chance += Game.CharacterClass.UnpriestlyWeaponAdditionalFailureChance;
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

    public void Initialize(ItemFactory itemFactory, int spellIndex) // TODO: This can be a game event for "CharacterClass_Changed"
    {
        _characterClassSpell = Game.SingletonRepository.Get<CharacterClassSpell>(CharacterClassSpell.GetCompositeKey(Game.CharacterClass, this));
        _spellIndex = spellIndex;
        _spellBookItemFactory = itemFactory;
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
            // Retrieve the learned details for the spell.
            string? learnedDetails = LearnedDetails;

            // Check to see if the spell learned details is null.
            if (learnedDetails is null)
            {
                // We will default the details to blank, if there are no scripts.
                learnedDetails = "";
                MappedSpellScript mappedSpellScript = GetMappedSpellScripts(true);
                ICastSpellScript[]? castSpellScripts = mappedSpellScript.CastSpellScripts;
                if (castSpellScripts is not null)
                {
                    // A null value for learned details for a spell, means to use the associated scripts.
                    List<string> learnedDetailsList = new List<string>();
                    foreach (ICastSpellScript castSpellScript in castSpellScripts)
                    {
                        string castSpellScriptLearnedDetails = castSpellScript.LearnedDetails;
                        if (!learnedDetailsList.Contains(castSpellScriptLearnedDetails))
                        {
                            learnedDetailsList.Add(castSpellScriptLearnedDetails);
                        }
                    }

                    learnedDetails = String.Join(" ", learnedDetailsList);
                }
            }
            info = !Tried ? "untried" : learnedDetails;
        }

        return CharacterClassSpell.Level >= 99 ? "(illegible)" : $"{Name,-30} {CharacterClassSpell.Level,3} {CharacterClassSpell.ManaCost,4} {FailureChance(),3}% {info}";
    }

    /// <summary>
    /// Renders debugging details about the spell.  Should not be used in-game.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{nameof(Spell)}: {Name} (Lvl: {CharacterClassSpell.Level}, Mana: {CharacterClassSpell.ManaCost}, Fail: {CharacterClassSpell.BaseFailure}, 1st Exp: {CharacterClassSpell.FirstCastExperience})";
    }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    /// <returns></returns>
    private string? LearnedDetails { get; } = null;
}
