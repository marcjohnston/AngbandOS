namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xScript) };
}