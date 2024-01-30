// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VecnaTheEmperorLichMonsterRace : MonsterRace
{
    protected VecnaTheEmperorLichMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ManaBallMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(SummonKinMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperLSymbol));
    public override ColorEnum Color => ColorEnum.Gold;
    public override string Name => "Vecna, the Emperor Lich";

    public override int ArmorClass => 85;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp80AttackEffect)), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(UnPowerAttackEffect)), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseDexAttackEffect)), 2, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseDexAttackEffect)), 2, 12)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "He is a highly cunning, extremely magical being, spoken of in legends. This ancient shadow of death wilts any living thing it passes.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Vecna, the Emperor Lich";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 72;
    public override bool Male => true;
    public override int Mexp => 30000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Vecna    ";
    public override bool Undead => true;
    public override bool Unique => true;
}
