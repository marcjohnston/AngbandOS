namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AnimalTamingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AnimalTamingNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.AnimalTrainingScript) };
}