namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RestoreLifeSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RestoreLifeSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RestoreLifeDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RestoreLevelScript) };
}