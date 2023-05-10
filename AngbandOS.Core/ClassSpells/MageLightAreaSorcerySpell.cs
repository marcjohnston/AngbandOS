internal class MageLightAreaSorcerySpell : ClassSpell
{
    private MageLightAreaSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellLightArea);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}