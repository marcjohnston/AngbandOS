namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HobbitRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HobbitRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private HobbitRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}