internal class MonkBraveryCorporealSpell : ClassSpell
{
    private MonkBraveryCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBravery);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}