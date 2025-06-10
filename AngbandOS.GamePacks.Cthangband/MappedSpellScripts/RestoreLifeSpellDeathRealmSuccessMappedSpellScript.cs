namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RestoreLifeSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RestoreLifeDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RestoreLevelScript) };
}