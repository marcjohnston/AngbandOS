internal class MonkHealingCorporealSpell : ClassSpell
{
    private MonkHealingCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealing);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}