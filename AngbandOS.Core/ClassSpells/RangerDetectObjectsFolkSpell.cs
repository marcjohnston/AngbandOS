[Serializable]
internal class RangerDetectObjectsFolkSpell : ClassSpell
{
    private RangerDetectObjectsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectObjects);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 13;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}