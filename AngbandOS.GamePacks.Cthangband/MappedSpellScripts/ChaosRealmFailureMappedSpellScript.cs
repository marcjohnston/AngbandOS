namespace AngbandOS.GamePacks.Cthangband;

internal class ChaosRealmFailureMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override bool Success => false;
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WildChaoticMagicScript) };
}