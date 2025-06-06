namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MappedSpellScript : IGetKey
{
    protected readonly Game Game;
    protected MappedSpellScript(Game game)
    {
        Game = game;
    }

    public string GetKey => Game.GetCompositeKey(SpellBindingKey, RealmBindingKey, CharacterClassBindingKey, NamespaceKey);

    public void Bind()
    {
        Spell = Game.SingletonRepository.GetNullable<Spell>(SpellBindingKey);
        Realm = Game.SingletonRepository.GetNullable<Realm>(RealmBindingKey);
        CharacterClass = Game.SingletonRepository.GetNullable<BaseCharacterClass>(CharacterClassBindingKey);
        CastSpellScripts = Game.SingletonRepository.GetNullable<ICastSpellScript>(CastSpellScriptBindingKeys);
    }
    public static string GetCompositeKey(Game game, Realm? realm, Spell? spell, BaseCharacterClass? characterClass, string namespaceKey) => Game.GetCompositeKey(spell?.GetKey, realm?.GetKey, characterClass?.GetKey, namespaceKey);
    public static string SuccessNamespaceKey => "Success";
    public static string FailureNamespaceKey => "Failure";
    public string ToJson()
    {
        return "";
    }
    public Realm? Realm { get; private set; }
    public BaseCharacterClass? CharacterClass { get; private set; }
    public Spell? Spell { get; private set; }
    public ICastSpellScript[]? CastSpellScripts { get; set; }

    protected virtual string? RealmBindingKey { get; }
    protected virtual string? CharacterClassBindingKey { get; }
    protected virtual string? SpellBindingKey { get; }
    public virtual string NamespaceKey { get; }

    /// <summary>
    /// Returns the name of an <see cref="ICastSpellScript"/> script to be run, when the spell is cast; or null, if the spell does nothing when cast.  This
    /// property is used to bind the <see cref="CastSpellScripts"/> property during the bind phase.
    /// </summary>
    protected virtual string[]? CastSpellScriptBindingKeys { get; }

}