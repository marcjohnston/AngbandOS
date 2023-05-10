[Serializable]
internal class WarriorMageCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private WarriorMageCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}