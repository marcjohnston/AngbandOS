namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class HorrifySpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private HorrifySpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(HorrifyDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(HorrifyScript) };
}