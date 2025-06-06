namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResistLightningSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResistLightningSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResistLightningFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResistLightningScript) };
}