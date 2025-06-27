namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BreatheChaosSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BreatheChaosChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BreatheChaosProjectileScript) };
}