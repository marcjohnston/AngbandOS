[Serializable]
internal class RangerDetectMonstersFolkSpell : ClassSpell
{
    private RangerDetectMonstersFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectMonsters);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}