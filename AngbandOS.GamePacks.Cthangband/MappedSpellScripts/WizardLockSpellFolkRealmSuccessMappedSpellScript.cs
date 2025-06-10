namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WizardLockSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WizardLockFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(JamDoor1d30p20ProjectileScript) };
}