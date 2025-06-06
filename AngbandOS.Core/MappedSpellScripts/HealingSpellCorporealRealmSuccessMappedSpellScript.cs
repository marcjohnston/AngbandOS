namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HealingSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HealingSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HealingCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Healing300ResetStunAndBleedingScript) };
}