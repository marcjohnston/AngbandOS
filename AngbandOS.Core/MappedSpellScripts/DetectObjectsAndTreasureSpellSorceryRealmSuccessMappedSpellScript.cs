namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectObjectsAndTreasureSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectObjectsAndTreasureSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectObjectsAndTreasureSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectObjectsAndTreasureScript) };
}