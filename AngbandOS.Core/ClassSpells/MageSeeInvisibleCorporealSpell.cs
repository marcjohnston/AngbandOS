[Serializable]
internal class MageSeeInvisibleCorporealSpell : ClassSpell
{
    private MageSeeInvisibleCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeInvisible);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}