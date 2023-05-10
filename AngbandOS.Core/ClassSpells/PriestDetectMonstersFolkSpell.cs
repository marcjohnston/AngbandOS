[Serializable]
internal class PriestDetectMonstersFolkSpell : ClassSpell
{
    private PriestDetectMonstersFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectMonsters);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}