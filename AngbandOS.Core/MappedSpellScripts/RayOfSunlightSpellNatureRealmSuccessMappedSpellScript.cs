namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RayOfSunlightSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RayOfSunlightSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RayOfSunlightNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RayOfSunlightScript) };
}