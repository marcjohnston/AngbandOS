[Serializable]
internal class PriestGravityBeamChaosSpell : ClassSpell
{
    private PriestGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 8;
}