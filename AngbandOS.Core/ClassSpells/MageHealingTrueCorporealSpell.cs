internal class MageHealingTrueCorporealSpell : ClassSpell
{
    private MageHealingTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealingTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}