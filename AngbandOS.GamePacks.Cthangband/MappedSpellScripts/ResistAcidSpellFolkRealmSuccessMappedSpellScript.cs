namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ResistAcidSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ResistAcidFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AcidResistance1d20p20TimerScript) };
}
