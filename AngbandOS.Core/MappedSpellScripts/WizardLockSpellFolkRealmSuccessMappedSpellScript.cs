namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WizardLockSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WizardLockSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WizardLockFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Jamdoor1d30p20ProjectileScript) };
}