[Serializable]
internal class PriestCurePoisonFolkSpell : ClassSpell
{
    private PriestCurePoisonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCurePoison);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}