namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AnimalFriendshipSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AnimalFriendshipNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlAnimalAtLos2xProjectileScript) };
}