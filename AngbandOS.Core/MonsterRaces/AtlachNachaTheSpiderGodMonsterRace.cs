using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class AtlachNachaTheSpiderGodMonsterRace : MonsterRace
    {
        public override char Character => 'S';
        public override Colour Colour => Colour.Red;
        public override string Name => "Atlach-Nacha, the Spider God";

        public override bool Animal => true;
        public override int ArmourClass => 160;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 3, 9),
            new MonsterAttack(AttackType.Bite, new LoseStrAttackEffect(), 3, 9),
            new MonsterAttack(AttackType.Sting, new PoisonAttackEffect(), 2, 5),
            new MonsterAttack(AttackType.Sting, new LoseStrAttackEffect(), 2, 5)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheDark => true;
        public override bool BreathePoison => true;
        public override bool Confuse => true;
        public override bool DarkBall => true;
        public override bool Darkness => true;
        public override string Description => "'...there was a kind of face on the squat ebon body, low down amid the several-jointed legs. The face peered up with a weird expression of doubt and inquiry...'";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Atlach-Nacha, the Spider God";
        public override bool GreatOldOne => true;
        public override int Hdice => 130;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 75;
        public override int Mexp => 35000;
        public override bool MoveBody => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 8;
        public override bool OnlyDropItem => true;
        public override int Rarity => 1;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Atlach-Nacha";
        public override bool SummonCthuloid => true;
        public override bool SummonSpider => true;
        public override bool Unique => true;
    }
}
