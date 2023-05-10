[Serializable]
internal class WarriorMageHolyWordLifeSpell : ClassSpell
{
    private WarriorMageHolyWordLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyWord);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 45;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 125;
}