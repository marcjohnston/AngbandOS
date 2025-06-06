namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ChaosRealmFailureMappedSpellScript : MappedSpellScript
{
    private ChaosRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WildChaoticMagicScript) };
}