namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CallSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CallChaosChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CallChaosCancellableScript) };
}