namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlinkSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlinkSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlinkFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(PhaseDoorScript) };
}