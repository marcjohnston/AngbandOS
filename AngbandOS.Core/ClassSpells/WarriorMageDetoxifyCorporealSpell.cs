[Serializable]
internal class WarriorMageDetoxifyCorporealSpell : ClassSpell
{
    private WarriorMageDetoxifyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellDetoxify);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}