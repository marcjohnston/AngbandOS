namespace AngbandOS.GamePacks.Cthangband;

internal class ShardBallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ShardBallChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Shard1xp120r2ProjectileScript) };
}