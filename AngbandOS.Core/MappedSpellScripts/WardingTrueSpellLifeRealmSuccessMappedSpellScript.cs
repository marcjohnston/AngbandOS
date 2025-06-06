namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WardingTrueSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WardingTrueSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WardingTrueLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ElderSignScript), nameof(WardingProjectileScript) };
}