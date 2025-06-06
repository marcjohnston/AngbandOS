namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DeathRaySpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DeathRaySpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DeathRayDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DeathRayScript) };
}