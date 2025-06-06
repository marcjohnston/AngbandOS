namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfRecallSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfRecallSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfRecallCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ToggleRecallScript) };
}