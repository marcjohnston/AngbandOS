namespace AngbandOS.GamePacks.Cthangband;

internal class DisintegrateSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DisintegrateChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DisintegrateProjectileScript) };
}