namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HerbalHealingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HerbalHealingSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HerbalHealingNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HerbalHealingScript) };
}