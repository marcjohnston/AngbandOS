[Serializable]
internal class HighMageGravityBeamChaosSpell : ClassSpell
{
    private HighMageGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 8;
}