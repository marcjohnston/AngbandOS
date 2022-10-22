using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TulzschaMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Tulzscha";

        public override int ArmourClass => 170;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new Exp80AttackEffect();
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new BlindAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 10;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 10;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Engulf;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool BreatheFire => true;
        public override bool BreatheNether => true;
        public override string Description => "'A belching column of sick greenish flame... spouting volcanically from depths profound and inconceivable, casting no shadows as a healthy flame should, and coating the nitrous stone with a nasty venomous verdigris.' H.P.Lovecraft - 'The Festival'.";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool FireAura => true;
        public override bool FireBall => true;
        public override bool FireBolt => true;
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
        public override int Level => 57;
        public override bool ManaBolt => true;
        public override int Mexp => 30000;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override bool NetherBolt => true;
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
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
