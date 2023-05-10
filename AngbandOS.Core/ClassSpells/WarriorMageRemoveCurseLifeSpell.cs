[Serializable]
internal class WarriorMageRemoveCurseLifeSpell : ClassSpell
{
    private WarriorMageRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 18;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 4;
}