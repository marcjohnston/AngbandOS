namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectDoorsAndTrapsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectDoorsAndTrapsSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectDoorsAndTrapsFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectDoorsTrapsAndStairsScript) };
}