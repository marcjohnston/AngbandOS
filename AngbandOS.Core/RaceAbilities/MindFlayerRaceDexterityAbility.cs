namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MindFlayerRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MindFlayerRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private MindFlayerRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}