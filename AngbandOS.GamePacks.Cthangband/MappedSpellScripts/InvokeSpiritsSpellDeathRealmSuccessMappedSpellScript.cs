namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class InvokeSpiritsSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(InvokeSpiritsDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.InvokeSpiritsScript) };
}