namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class WonderSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private WonderSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(WonderChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SpellOfWonderScript) };
}