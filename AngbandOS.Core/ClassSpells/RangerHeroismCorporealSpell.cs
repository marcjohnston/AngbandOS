[Serializable]
internal class RangerHeroismCorporealSpell : ClassSpell
{
    private RangerHeroismCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHeroism);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 5;
}