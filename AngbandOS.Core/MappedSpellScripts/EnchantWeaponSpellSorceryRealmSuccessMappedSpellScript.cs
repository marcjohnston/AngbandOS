namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EnchantWeaponSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EnchantWeaponSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EnchantWeaponSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EnchantWeaponScript) };
}