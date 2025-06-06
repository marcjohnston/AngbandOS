namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RaiseTheDeadSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RaiseTheDeadSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RaiseTheDeadDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RaiseTheDeadScript) };
}