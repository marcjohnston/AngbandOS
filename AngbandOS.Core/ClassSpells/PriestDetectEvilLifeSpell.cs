[Serializable]
internal class PriestDetectEvilLifeSpell : ClassSpell
{
    private PriestDetectEvilLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDetectEvil);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 10;
    public override int FirstCastExperience => 4;
}