internal class PriestHealingCorporealSpell : ClassSpell
{
    private PriestHealingCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealing);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 22;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}