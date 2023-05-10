internal class HighMageMassSummonsTarotSpell : ClassSpell
{
    private HighMageMassSummonsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMassSummons);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 200;
}