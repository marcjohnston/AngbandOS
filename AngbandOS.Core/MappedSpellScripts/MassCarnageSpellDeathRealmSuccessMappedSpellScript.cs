namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MassCarnageSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MassCarnageSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MassCarnageDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MassCarnageScript) };
}