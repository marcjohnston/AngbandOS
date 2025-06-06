namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistFireSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistFireSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistFireFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistFireScript) };
}