namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ConfuseMonsterSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ConfuseMonsterSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ConfuseMonsterSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ConfuseMonsterScript) };
}