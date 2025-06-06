namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class LightAreaSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private LightAreaSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(LightAreaFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightAreaScript) };
}