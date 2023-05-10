[Serializable]
internal class PriestDetectObjectsFolkSpell : ClassSpell
{
    private PriestDetectObjectsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectObjects);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 11;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}