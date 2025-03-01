// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AcidicCytoplasmMonsterRace : MonsterRace
{
    protected AcidicCytoplasmMonsterRace(Game game) : base(game) { }


    protected override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Chartreuse;
    
    public override int ArmorClass => 18;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AcidAttackEffect), 1, 10),
        (nameof(TouchAttack), nameof(AcidAttackEffect), 1, 10),
        (nameof(TouchAttack), nameof(AcidAttackEffect), 1, 10),
        (nameof(TouchAttack), nameof(AcidAttackEffect), 1, 10)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A disgusting animated blob of destruction. Flee its gruesome hunger!";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Acidic cytoplasm";
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 35;
    public override int Mexp => 36;
    public override int NoticeRange => 12;
    public override bool OpenDoor => true;
    public override int Rarity => 5;
    public override int Sleep => 1;
    public override int Speed => 120;
    public override string? MultilineName => "Acidic\ncytoplasm";
    public override bool Stupid => true;
    public override bool TakeItem => true;
}
