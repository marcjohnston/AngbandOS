internal class PaladinCureCriticalWoundsLifeSpell : ClassSpell
{
    private PaladinCureCriticalWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}