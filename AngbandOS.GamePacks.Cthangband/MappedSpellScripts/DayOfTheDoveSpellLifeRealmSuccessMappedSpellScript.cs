namespace AngbandOS.GamePacks.Cthangband;

internal class DayOfTheDoveSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DayOfTheDoveLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlAnimalAtLos2xProjectileScript) };
}