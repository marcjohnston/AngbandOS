namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ExorcismSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ExorcismSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ExorcismLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ExorcismScript) };
}