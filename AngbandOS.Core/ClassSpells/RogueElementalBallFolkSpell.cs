[Serializable]
internal class RogueElementalBallFolkSpell : ClassSpell
{
    private RogueElementalBallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellElementalBall);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 42;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 30;
}