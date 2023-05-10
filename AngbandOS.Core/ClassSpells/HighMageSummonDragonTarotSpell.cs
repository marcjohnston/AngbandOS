[Serializable]
internal class HighMageSummonDragonTarotSpell : ClassSpell
{
    private HighMageSummonDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDragon);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 75;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}