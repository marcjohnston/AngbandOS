[Serializable]
internal class PriestShardBallChaosSpell : ClassSpell
{
    private PriestShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 47;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 150;
}