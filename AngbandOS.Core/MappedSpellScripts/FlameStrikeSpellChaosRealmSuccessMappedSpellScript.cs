namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FlameStrikeSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FlameStrikeSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FlameStrikeChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FlameStrikeScript) };
}