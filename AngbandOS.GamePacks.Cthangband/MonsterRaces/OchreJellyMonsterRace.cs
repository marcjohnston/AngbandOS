// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class OchreJellyMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerJSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 18;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 2, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 2, 6),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A fast moving highly acidic jelly thing, that is eating away the floor it rests on.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Ochre jelly";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 13;
    public override int Mexp => 40;
    public override int NoticeRange => 12;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override int Sleep => 1;
    public override int Speed => 120;
    public override string? MultilineName => "Ochre\njelly";
    public override bool Stupid => true;
    public override bool TakeItem => true;
}
