namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DoorCreationSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DoorCreationNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CreateDoorProjectileScript) };
}