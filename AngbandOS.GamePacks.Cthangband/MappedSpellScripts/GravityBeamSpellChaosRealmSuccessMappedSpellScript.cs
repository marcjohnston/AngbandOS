namespace AngbandOS.GamePacks.Cthangband;

internal class GravityBeamSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(GravityBeamChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(GravityBeamProjectileScript) };
}