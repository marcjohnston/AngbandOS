[Serializable]
internal class RangerSeeInvisibleCorporealSpell : ClassSpell
{
    private RangerSeeInvisibleCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeInvisible);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 25;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 3;
}