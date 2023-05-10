internal class HighMageMindBlastTarotSpell : ClassSpell
{
    private HighMageMindBlastTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMindBlast);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}