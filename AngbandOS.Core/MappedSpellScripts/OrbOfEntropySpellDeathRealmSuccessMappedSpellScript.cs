namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class OrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private OrbOfEntropySpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OrbOfEntropyScript) };
}