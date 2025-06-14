namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageCharacterClassChaosBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ChaosBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageChaosBoltScript) };
}