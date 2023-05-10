[Serializable]
internal class PriestFireBallChaosSpell : ClassSpell
{
    private PriestFireBallChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBall);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 12;
}