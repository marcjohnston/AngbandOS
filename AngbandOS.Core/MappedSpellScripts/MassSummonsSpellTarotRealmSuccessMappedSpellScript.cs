namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MassSummonsSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MassSummonsSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MassSummonsTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MassSummonsScript) };
}