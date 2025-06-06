namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistColdSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistColdSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistColdFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistCold1d20p20Script) };
}