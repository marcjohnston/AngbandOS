[Serializable]
internal class CultistFireBallChaosSpell : ClassSpell
{
    private CultistFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 13;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 12;
}