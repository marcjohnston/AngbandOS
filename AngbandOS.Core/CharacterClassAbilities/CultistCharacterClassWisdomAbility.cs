namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CultistCharacterClassWisdomAbility : CharacterClassAbility
{
    private CultistCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CultistCharacterClass);
    public override int Bonus => 0;
}