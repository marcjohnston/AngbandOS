namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ResistEnvironmentSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ResistEnvironmentNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ResistEnvironmentScript) };
}