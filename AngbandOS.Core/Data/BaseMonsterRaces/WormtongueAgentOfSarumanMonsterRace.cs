using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WormtongueAgentOfSarumanMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Wormtongue, Agent of Saruman";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.EatGold;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBolt => true;
        public override bool CreateTraps => true;
        public override string Description => "He's been spying for Saruman. He is a snivelling wretch with no morals.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Wormtongue, Agent of Saruman";
        public override int Hdice => 25;
        public override bool Heal => true;
        public override int Hside => 10;
        public override int Level => 8;
        public override bool Male => true;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PoisonBall => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Wormtongue ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
