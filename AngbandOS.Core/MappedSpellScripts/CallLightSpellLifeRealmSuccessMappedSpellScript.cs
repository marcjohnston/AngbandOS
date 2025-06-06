namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CallLightSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CallLightSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CallLightLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightAreaScript) };
}