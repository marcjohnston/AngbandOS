namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class StinkingCloudSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private StinkingCloudSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(StinkingCloudDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(StinkingCloudScript) };
}