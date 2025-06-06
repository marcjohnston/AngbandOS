namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectInvisibilitySpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectInvisibilitySpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectInvisibilityFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectInvisibilityScript) };
}