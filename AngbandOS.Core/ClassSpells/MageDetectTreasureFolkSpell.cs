[Serializable]
internal class MageDetectTreasureFolkSpell : ClassSpell
{
    private MageDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 8;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}