namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DeathDealingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DeathDealingTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelLivingAtLos3xProjectileScript) };
}