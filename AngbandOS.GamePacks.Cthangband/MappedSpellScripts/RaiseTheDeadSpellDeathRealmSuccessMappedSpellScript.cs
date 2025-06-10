namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RaiseTheDeadSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RaiseTheDeadDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RaiseTheDeadScript) };
}