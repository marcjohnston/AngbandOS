namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageFireBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FireBoltChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MageFireBoltOrBeamOfFireScript) };
}
