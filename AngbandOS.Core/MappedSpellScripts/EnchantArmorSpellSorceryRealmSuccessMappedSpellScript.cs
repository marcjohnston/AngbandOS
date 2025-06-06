namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EnchantArmorSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EnchantArmorSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EnchantArmorSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EnchantArmorScript) };
}