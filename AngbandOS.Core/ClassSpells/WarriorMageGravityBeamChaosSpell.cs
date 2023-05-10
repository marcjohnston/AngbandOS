[Serializable]
internal class WarriorMageGravityBeamChaosSpell : ClassSpell
{
    private WarriorMageGravityBeamChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellGravityBeam);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 20;
    public override int BaseFailure => 66;
    public override int FirstCastExperience => 8;
}