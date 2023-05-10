internal class HighMageSummonGreaterUndeadTarotSpell : ClassSpell
{
    private HighMageSummonGreaterUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonGreaterUndead);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 220;
}