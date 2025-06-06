namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WraithformSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WraithformSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WraithformCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WraithformScript) };
}