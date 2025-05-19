// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AbhothSourceOfUncleannessMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.NexusBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ChaosBallMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBallMonsterSpell),
        nameof(MonsterSpellsEnum.MindBlastMonsterSpell),
        nameof(MonsterSpellsEnum.DreadCurseMonsterSpell),
        nameof(MonsterSpellsEnum.HasteMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell),
        nameof(MonsterSpellsEnum.DemonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiDragonSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HoundSummonMonsterSpell),
        nameof(MonsterSpellsEnum.MonstersSummonMonsterSpell),
        nameof(MonsterSpellsEnum.ReaverSummonMonsterSpell),
        nameof(MonsterSpellsEnum.SpiderSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportAwayMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportLevelMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 100;

    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 30, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 30, 4),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.LoseIntAttackEffect), 1, 50),
        (nameof(CrawlAttack), nameof(AttackEffectsEnum.LoseWisAttackEffect), 1, 50)
    };

    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "A greyish horrid mass, which quobbs and quivers spawning monstrosities.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Abhoth, Source of Uncleanness";
    public override bool GreatOldOne => true;
    public override int Hdice => 90;
    public override int Hside => 99;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 93;
    public override bool LightningAura => true;
    public override bool Male => true;
    public override int Mexp => 49000;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistNexus => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Abhoth";
    public override bool Unique => true;
}
