internal class HighMageTarotDrawTarotSpell : ClassSpell
{
    private HighMageTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 8;
}