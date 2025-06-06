namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SatisfyHungerSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SatisfyHungerSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SatisfyHungerCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SatisfyHungerScript) };
}