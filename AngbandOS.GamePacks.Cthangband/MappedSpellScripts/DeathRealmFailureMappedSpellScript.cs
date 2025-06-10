namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DeathRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WildDeathMagicScript) };
}