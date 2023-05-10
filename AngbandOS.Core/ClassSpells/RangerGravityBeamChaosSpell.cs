internal class RangerGravityBeamChaosSpell : ClassSpell
{
    private RangerGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 8;
}