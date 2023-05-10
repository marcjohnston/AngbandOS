[Serializable]
internal class WarriorMageCureCriticalWoundsCorporealSpell : ClassSpell
{
    private WarriorMageCureCriticalWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 11;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 7;
}