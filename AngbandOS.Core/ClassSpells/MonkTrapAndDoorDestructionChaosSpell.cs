[Serializable]
internal class MonkTrapAndDoorDestructionChaosSpell : ClassSpell
{
    private MonkTrapAndDoorDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 4;
}