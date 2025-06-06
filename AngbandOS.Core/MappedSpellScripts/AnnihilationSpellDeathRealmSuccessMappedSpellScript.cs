namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AnnihilationSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AnnihilationSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AnnihilationDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AnnihilationScript) };
}