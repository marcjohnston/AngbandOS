internal class WarriorMageSummonSpidersTarotSpell : ClassSpell
{
    private WarriorMageSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}