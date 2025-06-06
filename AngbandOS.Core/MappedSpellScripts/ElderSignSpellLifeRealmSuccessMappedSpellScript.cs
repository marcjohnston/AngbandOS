namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ElderSignSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ElderSignSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ElderSignLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ElderSignScript) };
}