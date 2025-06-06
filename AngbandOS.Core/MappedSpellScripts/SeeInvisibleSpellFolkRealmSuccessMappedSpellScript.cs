namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SeeInvisibleSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SeeInvisibleSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SeeInvisibleFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SeeInvisible1d24p24Script) };
}