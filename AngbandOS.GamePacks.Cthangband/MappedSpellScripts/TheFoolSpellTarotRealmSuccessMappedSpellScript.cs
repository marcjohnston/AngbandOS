namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TheFoolSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TheFoolTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Bizarre1xPet1In2SummonWeightedRandom) };
}