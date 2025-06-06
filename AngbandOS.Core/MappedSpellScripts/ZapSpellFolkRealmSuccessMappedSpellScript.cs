namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ZapSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ZapSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ZapFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ZapScript) };
}