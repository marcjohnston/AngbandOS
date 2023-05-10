internal class WarriorMageWordOfDestructionChaosSpell : ClassSpell
{
    private WarriorMageWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}