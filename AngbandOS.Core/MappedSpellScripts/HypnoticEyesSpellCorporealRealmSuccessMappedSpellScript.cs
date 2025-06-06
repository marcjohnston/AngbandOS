namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HypnoticEyesSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HypnoticEyesSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HypnoticEyesCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HypnoticEyesScript) };
}