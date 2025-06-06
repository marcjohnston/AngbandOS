namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BurnResistanceSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BurnResistanceSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BurnResistanceCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BurnResistanceScript) };
}