internal class HighMageAstralLoreTarotSpell : ClassSpell
{
    private HighMageAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}