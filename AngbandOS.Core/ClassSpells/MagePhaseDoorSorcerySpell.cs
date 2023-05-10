[Serializable]
internal class MagePhaseDoorSorcerySpell : ClassSpell
{
    private MagePhaseDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellPhaseDoor);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 2;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}