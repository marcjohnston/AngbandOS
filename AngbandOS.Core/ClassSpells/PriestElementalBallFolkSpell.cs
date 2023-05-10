internal class PriestElementalBallFolkSpell : ClassSpell
{
    private PriestElementalBallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellElementalBall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 39;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 30;
}