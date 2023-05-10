internal class WarriorMageCureLightWoundsLifeSpell : ClassSpell
{
    private WarriorMageCureLightWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureLightWounds);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}