internal class MonkGravityBeamChaosSpell : ClassSpell
{
    private MonkGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 20;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 8;
}