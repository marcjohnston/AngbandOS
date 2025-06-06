namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DarknessStormSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DarknessStormSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DarknessStormDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DarknessStormScript) };
}