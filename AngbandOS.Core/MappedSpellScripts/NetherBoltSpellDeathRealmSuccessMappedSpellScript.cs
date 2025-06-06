namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class NetherBoltSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private NetherBoltSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(NetherBoltDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NetherBoltScript) };
}