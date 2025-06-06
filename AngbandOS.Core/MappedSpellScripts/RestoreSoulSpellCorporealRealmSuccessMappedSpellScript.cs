namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RestoreSoulSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RestoreSoulSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RestoreSoulCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RestoreLevelScript) };
}