namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DispelGoodSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DispelGoodSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DispelGoodDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelGoodAtLos4xProjectileScript) };
}