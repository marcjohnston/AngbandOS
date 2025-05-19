// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TselakusTheDreadlordMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DarkBallMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.KinSummonMonsterSpell)
    };

    public override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 150;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 4, 6)
    };
    public override bool ColdBlood => true;
    public override string Description => "This huge affront to existence twists and tears at the fabric of space.Darkness itself recoils from the touch of Tselakus as he leaves a trailof death and destruction. Mighty claws rend reality as heannihilates all in his path to your soul!";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Tselakus, the Dreadlord";
    public override int Hdice => 65;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 68;
    public override bool Male => true;
    public override int Mexp => 35000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string? MultilineName => "Tselakus";
    public override bool Undead => true;
    public override bool Unique => true;
}
