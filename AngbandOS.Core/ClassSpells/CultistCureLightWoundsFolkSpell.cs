internal class CultistCureLightWoundsFolkSpell : ClassSpell
{
    private CultistCureLightWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureLightWounds);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 44;
    public override int FirstCastExperience => 5;
}