[Serializable]
internal class MageElementalBallFolkSpell : ClassSpell
{
    private MageElementalBallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellElementalBall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 30;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 30;
}