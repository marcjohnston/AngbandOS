namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class NibelungRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private NibelungRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}