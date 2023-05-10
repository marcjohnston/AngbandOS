internal class RangerAstralBrandingTarotSpell : ClassSpell
{
    private RangerAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}