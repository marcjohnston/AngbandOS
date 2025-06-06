namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BlessWeaponSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BlessWeaponSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BlessWeaponLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BlessWeaponScript) };
}