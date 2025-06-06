namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectEvilSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectEvilSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectEvilDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectEvilMonstersScript) };
}