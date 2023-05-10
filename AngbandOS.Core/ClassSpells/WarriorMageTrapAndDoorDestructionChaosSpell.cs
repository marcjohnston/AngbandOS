[Serializable]
internal class WarriorMageTrapAndDoorDestructionChaosSpell : ClassSpell
{
    private WarriorMageTrapAndDoorDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 4;
}