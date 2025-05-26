namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CultistCharacterClassCharismaAbility : CharacterClassAbility
{
    private CultistCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CultistCharacterClass);
    public override int Bonus => -2;
}