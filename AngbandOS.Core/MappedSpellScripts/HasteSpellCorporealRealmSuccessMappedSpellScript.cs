namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HasteSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HasteSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HasteCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HasteScript) };
}