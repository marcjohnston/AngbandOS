namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RechargingSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RechargingSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RechargingSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RechargeItemScript) };
}