internal class HighMageSummonDemonTarotSpell : ClassSpell
{
    private HighMageSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}