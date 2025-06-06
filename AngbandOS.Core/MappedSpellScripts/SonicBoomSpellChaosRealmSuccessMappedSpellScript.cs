namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SonicBoomSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SonicBoomSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SonicBoomChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SonicBoomProjectileScript) };
}