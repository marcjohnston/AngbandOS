namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AstralSpyingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AstralSpyingSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AstralSpyingTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AddTelepathy25p1d30Script) };
}