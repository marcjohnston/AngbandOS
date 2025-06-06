namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ShardBallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ShardBallSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ShardBallChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Shard1xp120r2ProjectileScript) };
}