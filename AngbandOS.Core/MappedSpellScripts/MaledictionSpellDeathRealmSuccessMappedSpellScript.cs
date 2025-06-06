namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MaledictionSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MaledictionSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MaledictionDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MaledictionScript) };
}