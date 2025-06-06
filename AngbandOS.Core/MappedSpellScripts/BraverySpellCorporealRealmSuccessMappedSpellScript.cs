namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BraverySpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BraverySpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BraveryCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ResetFearTimerScript) };
}