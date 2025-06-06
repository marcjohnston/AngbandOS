namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CureMediumWoundsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CureMediumWoundsSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CureMediumWoundsFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CureMediumWounds4d8Script) };
}