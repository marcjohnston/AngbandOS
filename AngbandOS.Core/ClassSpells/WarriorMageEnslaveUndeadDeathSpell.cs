[Serializable]
internal class WarriorMageEnslaveUndeadDeathSpell : ClassSpell
{
    private WarriorMageEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}