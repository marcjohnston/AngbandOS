internal class PriestRemoveCurseLifeSpell : ClassSpell
{
    private PriestRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 38;
    public override int FirstCastExperience => 5;
}