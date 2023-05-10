[Serializable]
internal class WarriorMageShardBallChaosSpell : ClassSpell
{
    private WarriorMageShardBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellShardBall);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 48;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}