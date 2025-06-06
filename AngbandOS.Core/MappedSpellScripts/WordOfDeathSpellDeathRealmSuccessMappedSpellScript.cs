namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WordOfDeathSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WordOfDeathSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WordOfDeathDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelLivingAtLos3xProjectileScript) };
}