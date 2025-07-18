namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageMagicMissileSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MagicMissileChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageMagicMissileScript) };
}