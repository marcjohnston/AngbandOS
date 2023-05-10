[Serializable]
internal class WarriorMageDetectObjectsFolkSpell : ClassSpell
{
    private WarriorMageDetectObjectsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectObjects);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}