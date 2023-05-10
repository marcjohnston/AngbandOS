[Serializable]
internal class HighMageExtradimensionalBeingTarotSpell : ClassSpell
{
    private HighMageExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}