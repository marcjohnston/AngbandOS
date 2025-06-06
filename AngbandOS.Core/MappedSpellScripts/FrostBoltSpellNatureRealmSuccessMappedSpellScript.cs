namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FrostBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FrostBoltSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FrostBoltNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FrostBoltScript) };
}