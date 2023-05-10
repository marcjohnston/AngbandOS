internal class MageHealingCorporealSpell : ClassSpell
{
    private MageHealingCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealing);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 20;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}