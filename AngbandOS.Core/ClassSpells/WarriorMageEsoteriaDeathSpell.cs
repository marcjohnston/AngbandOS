[Serializable]
internal class WarriorMageEsoteriaDeathSpell : ClassSpell
{
    private WarriorMageEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 45;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}