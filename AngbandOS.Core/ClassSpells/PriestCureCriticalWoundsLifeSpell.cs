internal class PriestCureCriticalWoundsLifeSpell : ClassSpell
{
    private PriestCureCriticalWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}