namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ProtectionFromEvilSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ProtectionFromEvilLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ProtectionFromEvil3XP1d25TimerScript) };
}