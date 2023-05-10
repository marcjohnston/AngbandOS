internal class MageCureLightWoundsLifeSpell : ClassSpell
{
    private MageCureLightWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureLightWounds);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}