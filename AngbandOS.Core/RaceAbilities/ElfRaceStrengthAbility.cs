namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private ElfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}