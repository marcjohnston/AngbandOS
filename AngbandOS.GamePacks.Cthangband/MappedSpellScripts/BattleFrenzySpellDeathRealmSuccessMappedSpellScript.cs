namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BattleFrenzySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BattleFrenzyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.BattleFrenzyScript) };
}