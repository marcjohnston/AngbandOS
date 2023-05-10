internal class PaladinPrayerLifeSpell : ClassSpell
{
    private PaladinPrayerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellPrayer);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 50;
}