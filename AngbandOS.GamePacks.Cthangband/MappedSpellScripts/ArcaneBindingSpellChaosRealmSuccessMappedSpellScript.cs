namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ArcaneBindingSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ArcaneBindingChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RechargeItem40RechargeItemScript) };
}