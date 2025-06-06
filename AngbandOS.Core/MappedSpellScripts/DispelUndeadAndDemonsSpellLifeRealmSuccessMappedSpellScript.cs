namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DispelUndeadAndDemonsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DispelUndeadAndDemonsSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DispelUndeadAndDemonsLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelUndeadAndDemonsScript) };
}