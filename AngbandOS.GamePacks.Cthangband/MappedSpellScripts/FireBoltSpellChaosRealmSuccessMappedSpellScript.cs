namespace AngbandOS.GamePacks.Cthangband;
[Serializable]
internal class HighMageFireBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FireBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageFireBoltOrBeamOfFireScript) };
}