[Serializable]
internal class FanaticFireBallChaosSpell : ClassSpell
{
    private FanaticFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 12;
}