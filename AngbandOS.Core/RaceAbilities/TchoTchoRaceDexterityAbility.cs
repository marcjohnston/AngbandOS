namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private TchoTchoRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}