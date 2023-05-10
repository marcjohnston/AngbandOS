[Serializable]
internal class PriestRestoreSoulCorporealSpell : ClassSpell
{
    private PriestRestoreSoulCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreSoul);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 50;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}