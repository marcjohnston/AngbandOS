[Serializable]
internal class CultistCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private CultistCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}