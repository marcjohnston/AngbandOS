namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StoneTellSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StoneTellSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StoneTellNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemFullyScript) };
}