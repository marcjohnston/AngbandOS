internal class MageCurePoisonLifeSpell : ClassSpell
{
    private MageCurePoisonLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCurePoison);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}