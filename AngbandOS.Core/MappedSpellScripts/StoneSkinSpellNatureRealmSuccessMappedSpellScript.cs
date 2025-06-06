namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StoneSkinSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StoneSkinSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StoneSkinNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(StoneSkinScript) };
}