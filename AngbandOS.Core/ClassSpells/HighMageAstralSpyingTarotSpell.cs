[Serializable]
internal class HighMageAstralSpyingTarotSpell : ClassSpell
{
    private HighMageAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}