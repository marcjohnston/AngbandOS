namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonObjectSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonObjectSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonObjectTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonItemScript) };
}