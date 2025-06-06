namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportLevelSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportLevelSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportLevelFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportLevelScript) };
}