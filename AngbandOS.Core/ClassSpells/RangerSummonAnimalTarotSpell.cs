[Serializable]
internal class RangerSummonAnimalTarotSpell : ClassSpell
{
    private RangerSummonAnimalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAnimal);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}