internal class PaladinSenseUnseenLifeSpell : ClassSpell
{
    private PaladinSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}