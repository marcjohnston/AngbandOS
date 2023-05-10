[Serializable]
internal class PriestDetoxifyCorporealSpell : ClassSpell
{
    private PriestDetoxifyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellDetoxify);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 6;
}