namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageLightningBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(LightningBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageLightningBoltScript) };
}