namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageFrostBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FrostBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MageFrostBoltScript) };
}
