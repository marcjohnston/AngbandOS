namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private VampireRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}