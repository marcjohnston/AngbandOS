namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TerrorSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TerrorDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TurnAllAtLos1xp30ProjectileScript) };
}