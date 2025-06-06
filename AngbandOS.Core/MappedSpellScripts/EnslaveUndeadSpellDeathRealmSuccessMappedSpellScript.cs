namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EnslaveUndeadSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EnslaveUndeadSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EnslaveUndeadDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlUndead1xProjectileScript) };
}