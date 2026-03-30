namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal sealed class MappedSpellScript : IGetKey, IToJson
{
    private Game Game { get; }
    public MappedSpellScript(Game game, MappedSpellScriptGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Success = gameConfiguration.Success;
        RealmBindingKey = gameConfiguration.RealmBindingKey;
        SpellBindingKey = gameConfiguration.SpellBindingKey;
        CharacterClassBindingKey = gameConfiguration.CharacterClassBindingKey;
        CastSpellScriptBindingKeys = gameConfiguration.CastSpellScriptBindingKeys;
        MinimumExperienceLevel = gameConfiguration.MinimumExperienceLevel;
    }

    public string Key { get; }
    public string GetKey => Key;

    public void Bind()
    {
        Spell = Game.SingletonRepository.GetNullable<Spell>(SpellBindingKey);
        Realm = Game.SingletonRepository.GetNullable<Realm>(RealmBindingKey);
        CharacterClass = Game.SingletonRepository.GetNullable<CharacterClass>(CharacterClassBindingKey);
        CastSpellScripts = Game.SingletonRepository.GetNullable<ICastSpellScript>(CastSpellScriptBindingKeys);
    }
    public string ToJson()
    {
        MappedSpellScriptGameConfiguration definition = new MappedSpellScriptGameConfiguration()
        {
            Key = Key,
            Success = Success,
            RealmBindingKey = RealmBindingKey,
            SpellBindingKey = SpellBindingKey,
            CharacterClassBindingKey = CharacterClassBindingKey,
            CastSpellScriptBindingKeys = CastSpellScriptBindingKeys,
            MinimumExperienceLevel = MinimumExperienceLevel,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public int? MinimumExperienceLevel { get; }
    public Realm? Realm { get; private set; }
    public CharacterClass? CharacterClass { get; private set; }
    public Spell? Spell { get; private set; }
    public ICastSpellScript[]? CastSpellScripts { get; set; }

    private string? RealmBindingKey { get; }
    private string? CharacterClassBindingKey { get; }
    private string? SpellBindingKey { get; }

    /// <summary>
    /// Returns true, if the spell script applies when the spell is successful; otherwise, returns false, indicating that the script applies when the
    /// cast fails.  Returns true, by default.
    /// </summary>
    public bool Success { get; } = true;

    /// <summary>
    /// Returns the name of an <see cref="ICastSpellScript"/> script to be run, when the spell is cast; or null, if the spell does nothing when cast.  This
    /// property is used to bind the <see cref="CastSpellScripts"/> property during the bind phase.
    /// </summary>
    private string[]? CastSpellScriptBindingKeys { get; }
}
