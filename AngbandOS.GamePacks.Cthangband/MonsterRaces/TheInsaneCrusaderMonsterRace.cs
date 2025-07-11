// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheInsaneCrusaderMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.ShriekMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8)
    };
    public override bool BashDoor => true;
    public override string Description => "Once a powerful adventurer, this poor fighter has seen a few too many eldritch horrors in his time. Any shred of lucidity is long gone, but he still remains dangerous. He wanders aimlessly through the dungeon randomly stiking at foes both real and imagined, all the while screaming out at the world which caused his condition.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "The Insane Crusader";
    public override int Hdice => 18;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override bool Male => true;
    public override int Mexp => 1200;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "The\nInsane\nCrusader";
    public override bool Unique => true;
}
