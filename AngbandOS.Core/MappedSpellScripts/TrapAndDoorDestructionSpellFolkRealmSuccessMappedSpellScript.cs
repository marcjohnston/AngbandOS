namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TrapAndDoorDestructionSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TrapAndDoorDestructionSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TrapAndDoorDestructionFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TrapAndDoorDestructionScript) };
}