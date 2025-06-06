namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CarnageSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CarnageSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CarnageDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(GenocideScript) };
}