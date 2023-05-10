internal class RangerHealingCorporealSpell : ClassSpell
{
    private RangerHealingCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealing);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 37;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 8;
}