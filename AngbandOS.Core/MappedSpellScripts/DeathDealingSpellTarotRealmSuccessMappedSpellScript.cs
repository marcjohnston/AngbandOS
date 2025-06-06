namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DeathDealingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DeathDealingSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DeathDealingTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelLivingAtLos3xProjectileScript) };
}