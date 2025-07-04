// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ScathaTheWormMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ColdBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.CauseCriticalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperDSymbol);
    public override ColorEnum Color => ColorEnum.BrightPink;
    
    public override int ArmorClass => 130;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 10),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 10),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 10),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "An ancient and wise Dragon. Scatha has grown clever over the long years. His scales are covered with frost, and his breath sends a shower of ice into the air.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Scatha the Worm";
    public override int Hdice => 20;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 44;
    public override bool Male => true;
    public override int Mexp => 17000;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 70;
    public override int Speed => 120;
    public override string? MultilineName => "Scatha\nthe\nWorm";
    public override bool Unique => true;
}
