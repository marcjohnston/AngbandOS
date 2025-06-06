namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class InvokeSpiritsSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private InvokeSpiritsSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(InvokeSpiritsDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(InvokeSpiritsScript) };
}