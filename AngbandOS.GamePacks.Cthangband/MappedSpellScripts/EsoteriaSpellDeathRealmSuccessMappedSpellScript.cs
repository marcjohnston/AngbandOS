namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EsoteriaSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EsoteriaDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.EsoteriaScript) };
}