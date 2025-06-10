namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureMediumWoundsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureMediumWoundsFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureMediumWounds4d8Script) };
}