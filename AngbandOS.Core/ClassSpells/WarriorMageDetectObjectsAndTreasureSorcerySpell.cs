[Serializable]
internal class WarriorMageDetectObjectsAndTreasureSorcerySpell : ClassSpell
{
    private WarriorMageDetectObjectsAndTreasureSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectObjectsAndTreasure);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 15;
}