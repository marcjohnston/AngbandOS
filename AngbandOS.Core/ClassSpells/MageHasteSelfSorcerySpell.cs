internal class MageHasteSelfSorcerySpell : ClassSpell
{
    private MageHasteSelfSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellHasteSelf);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 12;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}