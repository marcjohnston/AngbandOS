namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private ElfRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}