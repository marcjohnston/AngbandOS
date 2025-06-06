namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectCreaturesSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectCreaturesSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectCreaturesNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectNormalMonstersScript) };
}