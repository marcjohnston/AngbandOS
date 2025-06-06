namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DeathRealmFailureMappedSpellScript : MappedSpellScript
{
    private DeathRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WildDeathMagicScript) };
}