namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WraithformSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WraithformSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WraithformDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(WraithformScript) };
}