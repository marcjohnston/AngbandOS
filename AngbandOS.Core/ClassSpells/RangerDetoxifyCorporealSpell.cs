internal class RangerDetoxifyCorporealSpell : ClassSpell
{
    private RangerDetoxifyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellDetoxify);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 25;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 3;
}