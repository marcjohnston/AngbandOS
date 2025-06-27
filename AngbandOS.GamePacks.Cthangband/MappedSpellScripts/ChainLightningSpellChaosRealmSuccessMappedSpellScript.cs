namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ChainLightningSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ChainLightningChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ChainLightingProjectileScript) };
}