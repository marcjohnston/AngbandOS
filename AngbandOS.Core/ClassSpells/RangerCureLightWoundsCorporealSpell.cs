internal class RangerCureLightWoundsCorporealSpell : ClassSpell
{
    private RangerCureLightWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureLightWounds);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 2;
}