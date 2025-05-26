namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DraconianRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DraconianRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private DraconianRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}