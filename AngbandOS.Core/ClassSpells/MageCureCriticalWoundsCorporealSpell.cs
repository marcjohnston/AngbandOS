[Serializable]
internal class MageCureCriticalWoundsCorporealSpell : ClassSpell
{
    private MageCureCriticalWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}