namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SeeMagicSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SeeMagicSpellCorporealRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SeeMagicCorporealSpell);
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectMagicalObjectsScript) };
}