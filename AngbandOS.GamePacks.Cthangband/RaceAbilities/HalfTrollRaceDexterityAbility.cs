namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTrollRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -4;
}