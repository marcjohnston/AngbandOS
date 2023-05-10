[Serializable]
internal class RangerEsoteriaDeathSpell : ClassSpell
{
    private RangerEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 45;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}