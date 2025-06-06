namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HellfireSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HellfireSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HellfireDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HellfireScript) };
}