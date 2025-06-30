// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class Spell : IGetKey, IToJson
{
    protected readonly Game Game;

    public Spell(Game game, SpellGameConfiguration spellGameConfiguration)
    {
        Game = game;
        Key = spellGameConfiguration.Key ?? spellGameConfiguration.GetType().Name;
        Name = spellGameConfiguration.Name;
        LearnedDetails = spellGameConfiguration.LearnedDetails;
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
            Name = Name,
            LearnedDetails = LearnedDetails
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

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
    /// Returns the name of the spell, as rendered to the Game.
    /// </summary>
    public virtual string Name { get; }

    /// <summary>
    /// Returns true, if the spell has been attempted to be cast; false, otherwise.  Set to false, by default.  Set to true, the first time the player attempts to cast the
    /// spell; regardless of success or failure.
    /// </summary>
    public bool Tried = false;

    /// <remarks>
    /// This is initialized after the player selects a character class.
    /// </remarks>
    public CharacterClassSpell CharacterClassSpell { get; private set; }
  
    /// <summary>
    /// Returns the spell scripts that are associated with either the success or failure of casting a spell.  This is done by performing a lookup through the spell script
    /// mapping repository.
    /// </summary>
    /// <param name="namespaceKey"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private ICastSpellScript[]? GetMappedSpellScripts(bool successScript)
    {
        // Retrieve the entire table.
        MappedSpellScript[] table = Game.SingletonRepository.Get<MappedSpellScript>(); // TODO: This will be slow because the GenericRepository is type casting every record.

        // Retrieve all of the matching records.
        MappedSpellScript[]? matching = table.Where(_mappedSpellScript =>
            (_mappedSpellScript.Spell is null || _mappedSpellScript.Spell == this) &&
            (_mappedSpellScript.Realm is null || _mappedSpellScript.Realm == SpellBookItemFactory.Realm) &&
            (_mappedSpellScript.CharacterClass is null || _mappedSpellScript.CharacterClass == Game.BaseCharacterClass) &&
            (_mappedSpellScript.MinimumExperienceLevel is null || _mappedSpellScript.MinimumExperienceLevel < Game.ExperienceLevel.IntValue) &&
            _mappedSpellScript.Success == successScript)
            .OrderByDescending(_mappedSpellScript => _mappedSpellScript.MinimumExperienceLevel) // NULL values are treated as the lowest values in LINQ
            .ToArray();

        // Organize them into number of matching criteria and the matching signature.  The order of precedence is determined by number of matching criteria, similar to CSS select queries.
        // a -> Spell
        // b -> Realm
        // c -> Character Class
        // d -> Minimum Experience Level
        Dictionary<string, List<MappedSpellScript>> matchingDictionaryBySignature = new Dictionary<string, List<MappedSpellScript>>();
        foreach (MappedSpellScript mappedSpellScript in matching)
        {
            string signature = "";
            if (mappedSpellScript.Spell is not null)
            {
                signature = $"{signature}a";
            }
            if (mappedSpellScript.Realm is not null)
            {
                signature = $"{signature}b";
            }
            if (mappedSpellScript.CharacterClass is not null)
            {
                signature = $"{signature}c";
            }
            if (mappedSpellScript.MinimumExperienceLevel is not null)
            {
                signature = $"{signature}d";
            }
            if (!matchingDictionaryBySignature.TryGetValue(signature, out List<MappedSpellScript>? matchList))
            {
                matchList = new List<MappedSpellScript>();
                matchingDictionaryBySignature.Add(signature, matchList);
            }
            matchList.Add(mappedSpellScript);
        }

        // Retrieves the records based on a signature and returns the highest minimum experience.
        MappedSpellScript? GetBySignature(string signature)
        {
            if (matchingDictionaryBySignature.TryGetValue(signature, out List<MappedSpellScript>? list))
            {
                // The only variation can be minimum experience level.  We take the one with the highest minimum required experience.
                return list.OrderByDescending(_mappedSpellScript => _mappedSpellScript.MinimumExperienceLevel).First();
            }
            return null;
        }

        // Retrieve records for each of the associated signatures, detecting ambiguity across multiple signatures.
        MappedSpellScript? CheckSignatures(params string[] signatures)
        {
            MappedSpellScript? authorativeMappedSpellScript = null;
            foreach (string signature in signatures)
            {
                MappedSpellScript? mappedSpellScript = GetBySignature(signature);
                if (mappedSpellScript != null)
                {
                    if (authorativeMappedSpellScript != null)
                    {
                        throw new Exception("Ambigious matching scripts.");
                    }
                    authorativeMappedSpellScript = mappedSpellScript;
                }
            }
            return authorativeMappedSpellScript;
        }

        // Check for highest order of precedence, similar to CSS query selections.
        MappedSpellScript? fourMatching = CheckSignatures("abcd");
        if (fourMatching != null)
        {
            return fourMatching.CastSpellScripts;
        }
        MappedSpellScript? threeMatching = CheckSignatures("abc", "abd", "acd", "bcd");
        if (threeMatching != null)
        {
            return threeMatching.CastSpellScripts;
        }
        MappedSpellScript? twoMatching = CheckSignatures("ab", "ac", "ad", "bc", "bd", "cd");
        if (twoMatching != null)
        {
            return twoMatching.CastSpellScripts;
        }
        MappedSpellScript? oneMatching = CheckSignatures("a", "b", "c", "d");
        if (oneMatching != null)
        {
            return oneMatching.CastSpellScripts;
        }
        MappedSpellScript? zeroMatching = CheckSignatures("");
        if (zeroMatching != null)
        {
            return zeroMatching.CastSpellScripts;
        }
        throw new Exception($"No {(successScript ? "success" : "failure")} mapping found for {SpellBookItemFactory.Realm.GetKey}, {this.GetKey}, {Game.BaseCharacterClass.GetKey}.");
    }

    private ICastSpellScript[]? CastSpellScripts => GetMappedSpellScripts(true);

    private ICastSpellScript[]? FailedCastSpellScripts => GetMappedSpellScripts(false);

    /// <summary>
    /// Performs the spell.
    /// </summary>
    public void CastSpell()
    {
        ExecuteSpellScripts(CastSpellScripts);
    }

    /// <summary>
    /// This event is thrown when a spell cast fails by chance. When a spell cast fails, a second roll is made with the same failure
    /// chance to determine if a failure cast should happen.
    /// </summary>
    public void CastFailed()
    {
        ExecuteSpellScripts(FailedCastSpellScripts);
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
        chance -= 3 * (Game.BaseCharacterClass.SpellStat.SpellFailureReduction - 1);
        if (CharacterClassSpell.ManaCost > Game.Mana.IntValue)
        {
            chance += 5 * (CharacterClassSpell.ManaCost - Game.Mana.IntValue);
        }
        int minfail = Game.BaseCharacterClass.SpellStat.SpellMinFailChance;
        int characterClassMinimumSpellFailureChance = Game.BaseCharacterClass.SpellMinFailChance ?? 0;
        if (minfail < characterClassMinimumSpellFailureChance)
        {
            minfail = characterClassMinimumSpellFailureChance;
        }
        if ((Game.BaseCharacterClass.ID == CharacterClassEnum.Priest || Game.BaseCharacterClass.ID == CharacterClassEnum.Druid) && Game.Bonuses.HasUnpriestlyWeapon)
        {
            chance += 25;
        }
        if (Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist && Game.Bonuses.HasUnpriestlyWeapon)
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

    public void Initialize(ItemFactory itemFactory, int spellIndex) // TODO: This can be a game event for "CharacterClass_Changed"
    {
        CharacterClassSpell = Game.SingletonRepository.Get<CharacterClassSpell>(CharacterClassSpell.GetCompositeKey(Game.BaseCharacterClass, this));
        SpellIndex = spellIndex;
        SpellBookItemFactory = itemFactory;
        //CastSpellScripts = GetMappedSpellScripts(true);
        //FailedCastSpellScripts = GetMappedSpellScripts(false);
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
                if (CastSpellScripts is not null)
                {
                    // A null value for learned details for a spell, means to use the associated scripts.
                    List<string> learnedDetailsList = new List<string>();
                    foreach (ICastSpellScript castSpellScript in CastSpellScripts)
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
        return $"{Name} ({CharacterClassSpell.Level}, {CharacterClassSpell.ManaCost}, {CharacterClassSpell.BaseFailure}, {CharacterClassSpell.FirstCastExperience})";
    }

    /// <summary>
    /// Returns information about the spell, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    /// <returns></returns>
    protected virtual string? LearnedDetails { get; } = null;
}
