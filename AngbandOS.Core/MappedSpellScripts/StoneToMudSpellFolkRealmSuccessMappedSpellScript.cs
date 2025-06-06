namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StoneToMudSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StoneToMudSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StoneToMudFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(StoneToMudScript) };
}