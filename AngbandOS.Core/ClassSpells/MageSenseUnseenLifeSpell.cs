internal class MageSenseUnseenLifeSpell : ClassSpell
{
    private MageSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}