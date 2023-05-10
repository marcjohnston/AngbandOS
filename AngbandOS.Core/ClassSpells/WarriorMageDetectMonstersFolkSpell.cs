[Serializable]
internal class WarriorMageDetectMonstersFolkSpell : ClassSpell
{
    private WarriorMageDetectMonstersFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectMonsters);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}