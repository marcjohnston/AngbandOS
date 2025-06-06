namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CallSunlightSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CallSunlightSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CallSunlightNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CallSunlightScript) };
}