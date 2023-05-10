internal class WarriorMageElementalBallFolkSpell : ClassSpell
{
    private WarriorMageElementalBallFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellElementalBall);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 44;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 30;
}