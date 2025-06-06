namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SatisfyHungerSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SatisfyHungerSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SatisfyHungerFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SatisfyHungerScript) };
}