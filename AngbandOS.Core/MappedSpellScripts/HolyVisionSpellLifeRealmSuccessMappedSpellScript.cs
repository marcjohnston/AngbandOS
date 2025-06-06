namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HolyVisionSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HolyVisionSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HolyVisionLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemFullyScript) };
}