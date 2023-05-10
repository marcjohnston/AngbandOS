internal class RangerRestoreSoulCorporealSpell : ClassSpell
{
    private RangerRestoreSoulCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreSoul);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 50;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}