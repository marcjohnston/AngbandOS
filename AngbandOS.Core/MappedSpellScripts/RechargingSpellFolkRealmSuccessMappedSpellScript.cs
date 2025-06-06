namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RechargingSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RechargingSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RechargingFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RechargeItemScript) };
}