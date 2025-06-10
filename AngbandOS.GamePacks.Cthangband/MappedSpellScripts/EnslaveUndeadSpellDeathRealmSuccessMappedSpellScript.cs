namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EnslaveUndeadSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EnslaveUndeadDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ControlUndead1xProjectileScript) };
}