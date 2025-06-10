namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SummonDemonSpellChaosRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonDemonChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DemonServantSummonWeightedRandom) };
}