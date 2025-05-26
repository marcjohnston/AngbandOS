namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfGiantRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}