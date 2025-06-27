namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class FistOfForceSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FistOfForceChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FistOfForceProjectileScript) };
}