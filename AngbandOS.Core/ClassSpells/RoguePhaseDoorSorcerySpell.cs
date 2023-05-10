internal class RoguePhaseDoorSorcerySpell : ClassSpell
{
    private RoguePhaseDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellPhaseDoor);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 2;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 1;
}