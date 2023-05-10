[Serializable]
internal class MageElderSignLifeSpell : ClassSpell
{
    private MageElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 70;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 5;
}