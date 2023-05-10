internal class WarriorMagePhaseDoorSorcerySpell : ClassSpell
{
    private WarriorMagePhaseDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellPhaseDoor);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}