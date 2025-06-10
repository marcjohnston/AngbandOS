namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SummonAnimalSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonAnimalNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FriendlyAnimalSummonScript) };
}