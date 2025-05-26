namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpriteRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpriteRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SpriteRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}