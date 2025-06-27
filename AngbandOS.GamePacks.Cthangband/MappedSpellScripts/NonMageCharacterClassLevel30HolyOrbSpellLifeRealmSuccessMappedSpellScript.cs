namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageCharacterClassLevel30HolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageLevel30HolyOrbProjectileScript) };
    public override int? MinimumExperienceLevel => 30;
}