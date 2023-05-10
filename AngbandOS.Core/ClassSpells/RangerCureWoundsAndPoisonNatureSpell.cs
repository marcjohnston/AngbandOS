[Serializable]
internal class RangerCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private RangerCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 3;
}