namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private DraconianRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}