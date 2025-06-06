namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlackSleepSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlackSleepSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlackSleepDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSleep1xProjectileScript) };
}