[Serializable]
internal class HighMageShardBallChaosSpell : ClassSpell
{
    private HighMageShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 150;
}