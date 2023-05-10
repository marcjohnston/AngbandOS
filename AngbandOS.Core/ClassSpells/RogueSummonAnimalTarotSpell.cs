[Serializable]
internal class RogueSummonAnimalTarotSpell : ClassSpell
{
    private RogueSummonAnimalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAnimal);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}