namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageLightningBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(LightningBoltNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MageLightningBoltScript) };
}
