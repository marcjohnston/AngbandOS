[Serializable]
internal class PriestDetectTreasureFolkSpell : ClassSpell
{
    private PriestDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 9;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}