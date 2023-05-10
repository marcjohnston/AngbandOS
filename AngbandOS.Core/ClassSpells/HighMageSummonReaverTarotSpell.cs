[Serializable]
internal class HighMageSummonReaverTarotSpell : ClassSpell
{
    private HighMageSummonReaverTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReaver);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}