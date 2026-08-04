namespace AngbandOS.GamePacks.Cthangband;

internal class ResistLightningSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ResistLightningFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightningResistance20P1d20TimerScript) };
}