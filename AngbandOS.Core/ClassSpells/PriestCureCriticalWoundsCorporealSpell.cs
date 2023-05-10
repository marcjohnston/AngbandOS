internal class PriestCureCriticalWoundsCorporealSpell : ClassSpell
{
    private PriestCureCriticalWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 13;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}