internal class HighMageElementalBallFolkSpell : ClassSpell
{
    private HighMageElementalBallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellElementalBall);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 28;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 30;
}