namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HorrificVisageSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HorrificVisageSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HorrificVisageCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HorrificVisageScript) };
}