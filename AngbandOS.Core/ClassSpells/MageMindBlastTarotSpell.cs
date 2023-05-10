internal class MageMindBlastTarotSpell : ClassSpell
{
    private MageMindBlastTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMindBlast);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}