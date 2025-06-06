namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectMonstersSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectMonstersSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectMonstersFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectNormalMonstersScript) };
}