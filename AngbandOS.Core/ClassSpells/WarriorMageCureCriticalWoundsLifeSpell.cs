[Serializable]
internal class WarriorMageCureCriticalWoundsLifeSpell : ClassSpell
{
    private WarriorMageCureCriticalWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureCriticalWounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 22;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}