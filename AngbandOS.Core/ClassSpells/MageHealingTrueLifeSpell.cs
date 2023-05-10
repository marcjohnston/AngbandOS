internal class MageHealingTrueLifeSpell : ClassSpell
{
    private MageHealingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealingTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 115;
}