[Serializable]
internal class MonkShardBallChaosSpell : ClassSpell
{
    private MonkShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 48;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}