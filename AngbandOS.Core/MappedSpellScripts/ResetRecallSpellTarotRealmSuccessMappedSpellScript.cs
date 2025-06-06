namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ResetRecallSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ResetRecallSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ResetRecallTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResetRecallScript) };
}