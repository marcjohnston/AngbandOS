internal class HighMageFireBallChaosSpell : ClassSpell
{
    private HighMageFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 13;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 12;
}