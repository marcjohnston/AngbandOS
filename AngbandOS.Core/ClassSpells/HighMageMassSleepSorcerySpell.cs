[Serializable]
internal class HighMageMassSleepSorcerySpell : ClassSpell
{
    private HighMageMassSleepSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMassSleep);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 5;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}