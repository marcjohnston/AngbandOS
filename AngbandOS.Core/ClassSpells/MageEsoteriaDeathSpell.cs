[Serializable]
internal class MageEsoteriaDeathSpell : ClassSpell
{
    private MageEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 40;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}