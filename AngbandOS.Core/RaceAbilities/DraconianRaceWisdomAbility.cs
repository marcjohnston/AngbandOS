namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private DraconianRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}