[Serializable]
internal class CultistCureCriticalWoundsLifeSpell : ClassSpell
{
    private CultistCureCriticalWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}