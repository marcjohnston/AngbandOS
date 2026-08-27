namespace AngbandOS.GamePacks.Cthangband;

internal class DispelGoodSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DispelGoodDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelGoodAtLos4xProjectileScript) };
}