internal class RangerShardBallChaosSpell : ClassSpell
{
    private RangerShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 50;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 150;
}