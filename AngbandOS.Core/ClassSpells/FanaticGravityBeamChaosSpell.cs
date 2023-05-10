internal class FanaticGravityBeamChaosSpell : ClassSpell
{
    private FanaticGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 10;
}