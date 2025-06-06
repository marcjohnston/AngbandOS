namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonMonsterSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonMonsterSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonMonsterTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonMonsterScript) };
}