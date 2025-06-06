namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectEnchantmentSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectEnchantmentSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectEnchantmentSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectMagicalObjectsScript) };
}