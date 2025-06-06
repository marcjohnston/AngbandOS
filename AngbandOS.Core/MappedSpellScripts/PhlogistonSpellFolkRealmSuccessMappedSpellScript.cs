namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PhlogistonSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PhlogistonSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PhlogistonFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreatePhlogistonScript) };
}