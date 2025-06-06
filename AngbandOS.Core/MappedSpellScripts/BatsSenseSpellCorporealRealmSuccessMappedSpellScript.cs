namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BatsSenseSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BatsSenseSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BatsSenseCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MapAreaScript) };
}