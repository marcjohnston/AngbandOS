[Serializable]
internal class PaladinCallLightLifeSpell : ClassSpell
{
    private PaladinCallLightLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCallLight);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}