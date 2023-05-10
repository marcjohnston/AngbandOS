[Serializable]
internal class HighMageAstralBrandingTarotSpell : ClassSpell
{
    private HighMageAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 65;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 100;
}