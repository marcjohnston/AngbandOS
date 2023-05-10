[Serializable]
internal class MageCallLightLifeSpell : ClassSpell
{
    private MageCallLightLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCallLight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}