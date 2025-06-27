namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageMindBlastSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MindBlastTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageMindBlastScript) };
}