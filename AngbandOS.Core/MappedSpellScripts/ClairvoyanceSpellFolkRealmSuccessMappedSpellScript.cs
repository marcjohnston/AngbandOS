namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ClairvoyanceSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ClairvoyanceSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ClairvoyanceFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ClairvoyanceScript) };
}