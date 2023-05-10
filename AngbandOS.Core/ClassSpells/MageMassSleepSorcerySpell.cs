[Serializable]
internal class MageMassSleepSorcerySpell : ClassSpell
{
    private MageMassSleepSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMassSleep);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}