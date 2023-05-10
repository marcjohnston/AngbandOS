[Serializable]
internal class WarriorMageDetectTreasureFolkSpell : ClassSpell
{
    private WarriorMageDetectTreasureFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectTreasure);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}