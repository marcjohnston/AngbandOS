[Serializable]
internal class CultistPhaseDoorSorcerySpell : ClassSpell
{
    private CultistPhaseDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellPhaseDoor);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}