internal class MageConjureElementalTarotSpell : ClassSpell
{
    private MageConjureElementalTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellConjureElemental);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 28;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 12;
}