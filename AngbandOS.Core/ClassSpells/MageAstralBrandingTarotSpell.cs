internal class MageAstralBrandingTarotSpell : ClassSpell
{
    private MageAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 70;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}