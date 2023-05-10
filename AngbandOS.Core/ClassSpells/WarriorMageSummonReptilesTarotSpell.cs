[Serializable]
internal class WarriorMageSummonReptilesTarotSpell : ClassSpell
{
    private WarriorMageSummonReptilesTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReptiles);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}