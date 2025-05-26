namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SpriteRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}