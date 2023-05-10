[Serializable]
internal class MageShardBallChaosSpell : ClassSpell
{
    private MageShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}