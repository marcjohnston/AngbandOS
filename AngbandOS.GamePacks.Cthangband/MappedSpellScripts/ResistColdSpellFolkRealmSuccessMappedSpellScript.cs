namespace AngbandOS.GamePacks.Cthangband;

internal class ResistColdSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ResistColdFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ColdResistance20P1d20TimerScript) };
}