namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectDoorsAndTrapsSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectDoorsAndTrapsSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectDoorsAndTrapsSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectDoorsTrapsAndStairsScript) };
}