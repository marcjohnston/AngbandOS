internal class MageSummonDemonTarotSpell : ClassSpell
{
    private MageSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}