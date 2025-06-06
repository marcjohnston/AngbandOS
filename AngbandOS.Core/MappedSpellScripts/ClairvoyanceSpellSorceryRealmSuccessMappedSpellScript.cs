namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ClairvoyanceSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ClairvoyanceSpellSorceryRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ClairvoyanceSorcerySpell);
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ClairvoyanceScript) };
}