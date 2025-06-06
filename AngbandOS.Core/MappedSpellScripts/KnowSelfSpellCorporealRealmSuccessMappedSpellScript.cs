namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class KnowSelfSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private KnowSelfSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(KnowSelfCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SelfKnowledgeScript) };
}