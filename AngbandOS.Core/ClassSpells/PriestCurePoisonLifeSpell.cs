internal class PriestCurePoisonLifeSpell : ClassSpell
{
    private PriestCurePoisonLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCurePoison);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 6;
    public override int BaseFailure => 38;
    public override int FirstCastExperience => 4;
}