namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectUnlifeSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectUnlifeSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectUnlifeDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectNonlivingScript) };
}