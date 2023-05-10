[Serializable]
internal class HighMageSummonUndeadTarotSpell : ClassSpell
{
    private HighMageSummonUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonUndead);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 75;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}