namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SenseUnseenSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SenseUnseenSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SenseUnseenLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SeeInvisible1d24p24Script) };
}