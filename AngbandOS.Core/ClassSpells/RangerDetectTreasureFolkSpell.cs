internal class RangerDetectTreasureFolkSpell : ClassSpell
{
    private RangerDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}