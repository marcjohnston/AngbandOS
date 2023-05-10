[Serializable]
internal class PriestSummonAnimalTarotSpell : ClassSpell
{
    private PriestSummonAnimalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAnimal);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}