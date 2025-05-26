namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private DraconianRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}