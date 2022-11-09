using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class AbhothSourceOfUncleannessMonsterRace : MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Abhoth, Source of Uncleanness";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new LoseConAttackEffect(), 30, 4),
            new MonsterAttack(AttackType.Hit, new LoseStrAttackEffect(), 30, 4),
            new MonsterAttack(AttackType.Touch, new LoseIntAttackEffect(), 1, 50),
            new MonsterAttack(AttackType.Crawl, new LoseWisAttackEffect(), 1, 50)
        };
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheNexus => true;
        public override bool CauseMortalWounds => true;
        public override bool ChaosBall => true;
        public override bool Demon => true;
        public override string Description => "A greyish horrid mass, which quobbs and quivers spawning monstrosities.";
        public override bool DreadCurse => true;
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Abhoth, Source of Uncleanness";
        public override bool GreatOldOne => true;
        public override bool Haste => true;
        public override int Hdice => 90;
        public override bool Heal => true;
        public override int Hside => 99;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 93;
        public override bool LightningAura => true;
        public override bool Male => true;
        public override bool ManaBall => true;
        public override int Mexp => 49000;
        public override bool MindBlast => true;
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
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Abhoth   ";
        public override bool SummonCthuloid => true;
        public override bool SummonDemon => true;
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonHound => true;
        public override bool SummonMonsters => true;
        public override bool SummonReaver => true;
        public override bool SummonSpider => true;
        public override bool TeleportAway => true;
        public override bool TeleportLevel => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
