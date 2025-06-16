namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SummonAncientDragonSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonAncientDragonTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AncientDragon1xPet7In10SummonWeightedRandom) };
}