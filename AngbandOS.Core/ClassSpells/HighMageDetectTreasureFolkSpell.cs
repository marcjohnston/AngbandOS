[Serializable]
internal class HighMageDetectTreasureFolkSpell : ClassSpell
{
    private HighMageDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 7;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}