using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OrientalVampireMonsterRace : Base2MonsterRace
    {
        public override char Character => 'V';
        public override Colour Colour => Colour.Green;
        public override string Name => "Oriental vampire";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Exp40;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "The oriental vampire is a mist-like creature.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Oriental vampire";
        public override int Hdice => 28;
        public override bool Hold => true;
        public override int Hside => 12;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 34;
        public override int Mexp => 750;
        public override bool MindBlast => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Oriental  ";
        public override string SplitName3 => "  vampire   ";
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}
