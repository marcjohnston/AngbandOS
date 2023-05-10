[Serializable]
internal class MageGravityBeamChaosSpell : ClassSpell
{
    private MageGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 8;
}