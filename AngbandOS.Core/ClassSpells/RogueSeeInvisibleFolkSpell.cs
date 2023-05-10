internal class RogueSeeInvisibleFolkSpell : ClassSpell
{
    private RogueSeeInvisibleFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSeeInvisible);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 13;
}