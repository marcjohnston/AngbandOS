namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HobbitRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}