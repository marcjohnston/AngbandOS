internal class MageTrapAndDoorDestructionChaosSpell : ClassSpell
{
    private MageTrapAndDoorDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 2;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 4;
}