internal class WarriorMageFireBallChaosSpell : ClassSpell
{
    private WarriorMageFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 12;
}