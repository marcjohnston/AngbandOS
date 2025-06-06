namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DarkBoltSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DarkBoltSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DarkBoltDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DarkBoltScript) };
}