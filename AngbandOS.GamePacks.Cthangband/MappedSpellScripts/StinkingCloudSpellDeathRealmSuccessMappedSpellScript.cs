namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class StinkingCloudSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(StinkingCloudDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.StinkingCloudScript) };
}