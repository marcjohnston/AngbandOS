internal class RogueAstralBrandingTarotSpell : ClassSpell
{
    private RogueAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}