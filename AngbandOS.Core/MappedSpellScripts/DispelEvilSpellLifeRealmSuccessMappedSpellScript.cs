namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DispelEvilSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DispelEvilSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DispelEvilLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelEvilAtLos4xProjectileScript) };
}