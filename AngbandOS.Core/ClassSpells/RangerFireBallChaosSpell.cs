[Serializable]
internal class RangerFireBallChaosSpell : ClassSpell
{
    private RangerFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 15;
}