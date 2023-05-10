internal class MageHolyWordLifeSpell : ClassSpell
{
    private MageHolyWordLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyWord);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 125;
}