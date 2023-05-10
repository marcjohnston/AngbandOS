internal class WarriorMagePrayerLifeSpell : ClassSpell
{
    private WarriorMagePrayerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellPrayer);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 50;
}