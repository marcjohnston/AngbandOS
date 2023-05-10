[Serializable]
internal class PriestCureLightWoundsCorporealSpell : ClassSpell
{
    private PriestCureLightWoundsCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellCureLightWounds);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 4;
}