namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ProtectFromCorrosionSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ProtectFromCorrosionSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ProtectFromCorrosionNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RustProofScript) };
}