namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SatisfyHungerSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SatisfyHungerSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SatisfyHungerLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SatisfyHungerScript) };
}