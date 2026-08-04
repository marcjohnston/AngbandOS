namespace AngbandOS.GamePacks.Cthangband;

internal class NonMageCharacterClassHolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageHolyOrbProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
