namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EaglesVisionSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EaglesVisionSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EaglesVisionCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EaglesVisionScript) };
}