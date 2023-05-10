[Serializable]
internal class MonkExtradimensionalBeingTarotSpell : ClassSpell
{
    private MonkExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 110;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}