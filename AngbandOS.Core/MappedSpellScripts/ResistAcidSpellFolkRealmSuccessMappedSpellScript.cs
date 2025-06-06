namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistAcidSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistAcidSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistAcidFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistAcidScript) };
}