internal class CultistGravityBeamChaosSpell : ClassSpell
{
    private CultistGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 8;
}