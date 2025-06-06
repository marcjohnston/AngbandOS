namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WhirlwindAttackSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WhirlwindAttackSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WhirlwindAttackNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WhirlwindAttackScript) };
}