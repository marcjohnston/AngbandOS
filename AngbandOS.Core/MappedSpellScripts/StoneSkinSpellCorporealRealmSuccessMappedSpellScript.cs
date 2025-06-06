namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StoneSkinSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StoneSkinSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StoneSkinCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(StoneSkinScript) };
}