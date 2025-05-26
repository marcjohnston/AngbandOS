namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private ElfRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}