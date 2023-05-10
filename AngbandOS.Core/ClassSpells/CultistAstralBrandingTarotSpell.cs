[Serializable]
internal class CultistAstralBrandingTarotSpell : ClassSpell
{
    private CultistAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}