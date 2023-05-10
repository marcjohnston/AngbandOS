[Serializable]
internal class HighMageSummonReptilesTarotSpell : ClassSpell
{
    private HighMageSummonReptilesTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReptiles);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 30;
}