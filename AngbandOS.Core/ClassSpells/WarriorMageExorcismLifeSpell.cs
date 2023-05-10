[Serializable]
internal class WarriorMageExorcismLifeSpell : ClassSpell
{
    private WarriorMageExorcismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellExorcism);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}