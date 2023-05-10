[Serializable]
internal class RangerSeeInvisibleFolkSpell : ClassSpell
{
    private RangerSeeInvisibleFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSeeInvisible);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 13;
}