namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class VampirismTrueSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private VampirismTrueSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(VampirismTrueDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(VampirismTrueScript) };
}