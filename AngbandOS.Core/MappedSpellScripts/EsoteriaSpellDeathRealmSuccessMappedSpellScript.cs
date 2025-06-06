namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EsoteriaSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EsoteriaSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EsoteriaDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EsoteriaScript) };
}