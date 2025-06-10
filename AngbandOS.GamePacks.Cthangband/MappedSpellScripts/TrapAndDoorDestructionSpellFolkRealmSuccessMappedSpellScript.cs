namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TrapAndDoorDestructionSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TrapAndDoorDestructionFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.TrapAndDoorDestructionScript) };
}