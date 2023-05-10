internal class WarriorMageExtradimensionalBeingTarotSpell : ClassSpell
{
    private WarriorMageExtradimensionalBeingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellExtradimensionalBeing);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 120;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}