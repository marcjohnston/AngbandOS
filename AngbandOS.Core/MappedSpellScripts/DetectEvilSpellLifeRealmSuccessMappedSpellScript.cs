namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectEvilSpellLifeRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectEvilSpellLifeRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectEvilLifeSpell);
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectEvilMonstersScript) };
}