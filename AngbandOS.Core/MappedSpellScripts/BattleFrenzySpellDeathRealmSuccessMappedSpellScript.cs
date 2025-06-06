namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BattleFrenzySpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BattleFrenzySpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BattleFrenzyDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BattleFrenzyScript) };
}