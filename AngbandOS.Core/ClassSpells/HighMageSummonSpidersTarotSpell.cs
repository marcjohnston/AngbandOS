[Serializable]
internal class HighMageSummonSpidersTarotSpell : ClassSpell
{
    private HighMageSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}