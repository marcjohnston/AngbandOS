[Serializable]
internal class HighMageSummonObjectTarotSpell : ClassSpell
{
    private HighMageSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 8;
}