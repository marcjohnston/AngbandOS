namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DaylightSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DaylightSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DaylightNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CallDaylightScript) };
}