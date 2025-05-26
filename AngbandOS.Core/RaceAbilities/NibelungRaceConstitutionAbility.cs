namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class NibelungRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private NibelungRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}