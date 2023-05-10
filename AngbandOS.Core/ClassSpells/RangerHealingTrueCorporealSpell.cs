internal class RangerHealingTrueCorporealSpell : ClassSpell
{
    private RangerHealingTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealingTrue);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 80;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}