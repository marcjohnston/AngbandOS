namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RestoreBodySpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RestoreBodySpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RestoreBodyCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RestoreBodyScript) };
}