namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TeleportSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TeleportFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TeleportSelf5xTeleportSelfScript) };
}