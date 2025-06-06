namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HolyWordSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HolyWordSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HolyWordLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HolyWordScript) };
}