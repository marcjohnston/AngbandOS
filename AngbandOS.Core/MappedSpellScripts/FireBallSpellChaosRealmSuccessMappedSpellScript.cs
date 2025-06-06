namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FireBallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FireBallSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FireBallChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Fire1xp55r2ProjectileScript) };
}