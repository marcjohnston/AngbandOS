[Serializable]
internal class WarriorMageBlizzardNatureSpell : ClassSpell
{
    private WarriorMageBlizzardNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellBlizzard);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 29;
}