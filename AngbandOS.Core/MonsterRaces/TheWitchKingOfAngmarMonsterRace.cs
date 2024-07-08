// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheWitchKingOfAngmarMonsterRace : MonsterRace
{
    protected TheWitchKingOfAngmarMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonKinMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(TeleportAwayMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperWSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 120;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(HurtAttackEffect), 10, 10),
        (nameof(HitAttack), nameof(Exp80AttackEffect), 5, 5),
        (nameof(HitAttack), nameof(Exp80AttackEffect), 5, 5)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "The Chief of the Ringwraiths. A fell being of devastating power. His spells are lethal and his combat blows crushingly hard. He moves at speed, and commands legions of evil to do his bidding. It is said that he is fated never to die by the hand of mortal man.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "The Witch-King of Angmar";
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 80;
    public override bool Male => true;
    public override int Mexp => 42000;
    public override bool MoveBody => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "The\nWitch-King o\nAngmar";
    public override bool Undead => true;
    public override bool Unique => true;
}
