// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NightwingMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell)
    };

    public override string SymbolName => nameof(LowerZSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 120;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 6, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 6, 8)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "Everywhere colors seem paler and the air chiller. At the centre of the cold stands a mighty figure. Its wings envelop you in the chill of death as the nightwing reaches out to draw you into oblivion. Your muscles sag and your mind loses all will to fight as you stand in awe of this mighty being.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Nightwing";
    public override int Hdice => 60;
    public override int Hside => 30;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 50;
    public override int Mexp => 6000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Nightwing";
    public override bool Undead => true;
}
