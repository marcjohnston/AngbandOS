namespace AngbandOS.GamePacks.Cthangband;

internal class CallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CallChaosChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CallChaosProjectileScriptWeightedRandom) };
}