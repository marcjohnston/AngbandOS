internal class MonkSummonAnimalTarotSpell : ClassSpell
{
    private MonkSummonAnimalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAnimal);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}