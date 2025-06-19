namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KoboldRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 1;
}