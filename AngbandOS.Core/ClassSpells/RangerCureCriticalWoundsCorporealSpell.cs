[Serializable]
internal class RangerCureCriticalWoundsCorporealSpell : ClassSpell
{
    private RangerCureCriticalWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 3;
}