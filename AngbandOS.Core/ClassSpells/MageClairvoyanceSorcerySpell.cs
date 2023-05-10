[Serializable]
internal class MageClairvoyanceSorcerySpell : ClassSpell
{
    private MageClairvoyanceSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellClairvoyance);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 120;
}