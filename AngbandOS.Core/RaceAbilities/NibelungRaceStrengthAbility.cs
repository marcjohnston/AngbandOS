namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class NibelungRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private NibelungRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}