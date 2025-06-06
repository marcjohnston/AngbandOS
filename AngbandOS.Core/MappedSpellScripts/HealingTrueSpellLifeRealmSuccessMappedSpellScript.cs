namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HealingTrueSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HealingTrueSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HealingTrueLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HealingTrueScript) };
}