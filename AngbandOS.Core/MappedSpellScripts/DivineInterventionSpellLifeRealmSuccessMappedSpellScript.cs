namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DivineInterventionSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DivineInterventionSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DivineInterventionLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DivineInterventionScript) };
}