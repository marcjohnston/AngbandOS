[Serializable]
internal class HighMageCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private HighMageCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}