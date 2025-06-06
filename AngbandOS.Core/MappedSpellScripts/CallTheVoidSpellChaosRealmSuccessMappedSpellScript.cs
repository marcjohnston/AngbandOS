namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CallTheVoidSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private CallTheVoidSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(CallTheVoidChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(CallTheVoidScript) };
}