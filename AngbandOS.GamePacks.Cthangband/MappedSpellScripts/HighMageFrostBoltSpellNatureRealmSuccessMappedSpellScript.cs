namespace AngbandOS.GamePacks.Cthangband;
[Serializable]
internal class HighMageFrostBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FrostBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageFrostBoltScript) };
}