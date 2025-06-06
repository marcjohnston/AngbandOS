namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureLightWoundsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureLightWoundsSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureLightWoundsFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureLightWounds2d8Script) };
}