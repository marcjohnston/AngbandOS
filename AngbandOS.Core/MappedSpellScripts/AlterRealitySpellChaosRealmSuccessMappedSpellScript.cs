namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AlterRealitySpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AlterRealitySpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AlterRealityChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AlterRealityScript) };
}