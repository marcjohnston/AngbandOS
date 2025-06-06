namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class IdentifySpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private IdentifySpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(IdentifyFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemScript) };
}