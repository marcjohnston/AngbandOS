[Serializable]
internal class WarriorMageSummonHoundsTarotSpell : ClassSpell
{
    private WarriorMageSummonHoundsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonHounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 33;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}