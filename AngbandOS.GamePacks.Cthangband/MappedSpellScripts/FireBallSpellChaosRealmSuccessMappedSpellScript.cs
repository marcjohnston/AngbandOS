namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class FireBallSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FireBallChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Fire1xp55r2ProjectileScript) };
}