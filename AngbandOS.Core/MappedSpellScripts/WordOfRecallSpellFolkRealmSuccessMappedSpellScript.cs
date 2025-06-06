namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfRecallSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfRecallSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfRecallFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ToggleRecallScript) };
}