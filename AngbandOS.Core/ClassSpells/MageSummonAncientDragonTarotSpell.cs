internal class MageSummonAncientDragonTarotSpell : ClassSpell
{
    private MageSummonAncientDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAncientDragon);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}