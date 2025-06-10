namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ResistanceTrueSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ResistanceTrueNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ResistTrueScript) };
}