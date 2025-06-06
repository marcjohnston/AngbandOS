namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectionTrueSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectionTrueSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectionTrueSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectionScript) };
}