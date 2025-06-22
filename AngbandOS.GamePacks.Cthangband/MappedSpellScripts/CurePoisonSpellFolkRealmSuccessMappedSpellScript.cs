namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CurePoisonSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CurePoisonFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PoisonResetTimerScript) };
}