namespace AngbandOS.Core.RacialPowers;

[Serializable]
internal class DraconianRacePaladinCharacterClassRacialPower : RacialPower
{
    private DraconianRacePaladinCharacterClassRacialPower(Game game) : base(game) { }
    protected override string ScriptBindingKey => nameof(DraconianRaceHellFireOrHolyFireCharacterClassRacialPowerConditionalScript);
    protected override string RaceBindingKey => nameof(DraconianRace);
    protected override string? CharacterClassBindingKey => nameof(PaladinCharacterClass);
}