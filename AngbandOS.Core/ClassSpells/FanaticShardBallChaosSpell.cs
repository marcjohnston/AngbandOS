[Serializable]
internal class FanaticShardBallChaosSpell : ClassSpell
{
    private FanaticShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}