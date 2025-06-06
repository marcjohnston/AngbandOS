namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ElementalBallSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ElementalBallSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ElementalBallFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ElementalBallScript) };
}