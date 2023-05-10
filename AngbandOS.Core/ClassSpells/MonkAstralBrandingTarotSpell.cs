[Serializable]
internal class MonkAstralBrandingTarotSpell : ClassSpell
{
    private MonkAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}