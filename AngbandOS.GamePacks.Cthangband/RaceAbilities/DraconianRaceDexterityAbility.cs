namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DraconianRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 1;
}