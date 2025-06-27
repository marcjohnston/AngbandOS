namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class FlameStrikeSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(FlameStrikeChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FlameStrikeProjectileScript) };
}