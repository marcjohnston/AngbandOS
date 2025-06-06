namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TeleportAwaySpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TeleportAwaySpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TeleportAwayFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportAwayAll1xProjectileScript) };
}