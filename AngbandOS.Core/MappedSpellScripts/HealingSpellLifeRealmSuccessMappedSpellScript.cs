namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HealingSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HealingSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HealingLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Healing300ResetStunAndBleedingScript) };
}