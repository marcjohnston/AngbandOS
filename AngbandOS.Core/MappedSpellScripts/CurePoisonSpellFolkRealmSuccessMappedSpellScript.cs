namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CurePoisonSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CurePoisonSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CurePoisonFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CurePoisonScript) };
}