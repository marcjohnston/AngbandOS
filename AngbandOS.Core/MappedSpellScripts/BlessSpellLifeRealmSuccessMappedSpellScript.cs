namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlessSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlessSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlessLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BlessScript) };
}