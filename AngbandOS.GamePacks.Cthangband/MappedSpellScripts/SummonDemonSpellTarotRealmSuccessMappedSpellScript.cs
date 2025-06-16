namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SummonDemonSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonDemonTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Demon1xPet7In10SummonWeightedRandom) };
}