namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectTrapsAndSecretDoorsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectTrapsAndSecretDoorsSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectTrapsAndSecretDoorsLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectDoorsTrapsAndStairsScript) };
}