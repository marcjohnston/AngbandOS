namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectDoorsAndTrapsSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectDoorsAndTrapsSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectDoorsAndTrapsNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectDoorsTrapsAndStairsScript) };
}