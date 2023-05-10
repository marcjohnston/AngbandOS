[Serializable]
internal class RogueDetectTreasureFolkSpell : ClassSpell
{
    private RogueDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}