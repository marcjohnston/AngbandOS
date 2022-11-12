using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class GothmogTheHighCaptainOfBalrogsMonsterRace : MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.Red;
        public override string Name => "Gothmog, the High Captain of Balrogs";

        public override int ArmourClass => 140;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 9, 12),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 9, 12),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheDisintegration => true;
        public override bool BreatheFire => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "Gothmog is the Chief Balrog in Morgoth's personal guard. He is renowned for slaying Ecthelion the Warder of the Gates and he has never been defeated in combat. With his whip of flame and awesome fiery breath he saved his master from Ungoliant's rage.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Gothmog, the High Captain of Balrogs";
        public override int Hdice => 80;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int LevelFound => 95;
        public override bool Male => true;
        public override int Mexp => 43000;
        public override bool MoveBody => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Gothmog   ";
        public override bool SummonDemon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonKin => true;
        public override bool SummonReaver => true;
        public override bool Unique => true;
    }
}
