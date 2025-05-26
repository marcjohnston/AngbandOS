namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class NibelungRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private NibelungRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}