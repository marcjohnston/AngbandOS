namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EvocationSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EvocationSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EvocationDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EvocationScript) };
}