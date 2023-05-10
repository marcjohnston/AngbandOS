internal class MagePrayerLifeSpell : ClassSpell
{
    private MagePrayerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellPrayer);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 50;
}