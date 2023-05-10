internal class PriestRemoveFearLifeSpell : ClassSpell
{
    private PriestRemoveFearLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveFear);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}