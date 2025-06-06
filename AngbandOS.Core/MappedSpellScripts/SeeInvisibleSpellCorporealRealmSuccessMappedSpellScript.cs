namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SeeInvisibleSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SeeInvisibleSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SeeInvisibleCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SeeInvisible1d24p24Script) };
}