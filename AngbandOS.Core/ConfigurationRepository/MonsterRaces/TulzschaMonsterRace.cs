// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TulzschaMonsterRace : MonsterRace
{
    protected TulzschaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheFireMonsterSpell),
        nameof(BreatheNetherMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperXSymbol));
    public override ColorEnum Color => ColorEnum.Chartreuse;
    public override string Name => "Tulzscha";

    public override int ArmorClass => 170;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp80AttackEffect)), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(BlindAttackEffect)), 10, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 10, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(EngulfAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 10, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "'A belching column of sick greenish flame... spouting volcanically from depths profound and inconceivable, casting no shadows as a healthy flame should, and coating the nitrous stone with a nasty venomous verdigris.' H.P.Lovecraft - 'The Festival'.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Tulzscha";
    public override bool GreatOldOne => true;
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 57;
    public override int Mexp => 30000;
    public override bool MoveBody => true;
    public override bool NeverMove => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistNether => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Tulzscha  ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
