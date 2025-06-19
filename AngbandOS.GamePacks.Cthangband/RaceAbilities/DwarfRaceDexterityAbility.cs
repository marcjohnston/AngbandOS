namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DwarfRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -2;
}