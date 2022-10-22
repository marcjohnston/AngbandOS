using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FthagghuaLordOfTheFireVampiresMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Fthagghua, Lord of the fire vampires";

        public override int ArmourClass => 160;
        public override int Attack1DDice => 9;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Fire;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Fire;
        public override AttackType Attack3Type => AttackType.Engulf;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Engulf;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheFire => true;
        public override string Description => "A fiery serpentine entity, streaking through the air like a comet. The heat emanating from this creature is almost unbearable.";
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
        public override string FriendlyName => "Fthagghua, Lord of the fire vampires";
        public override bool GreatOldOne => true;
        public override int Hdice => 55;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int Level => 56;
        public override bool ManaBolt => true;
        public override int Mexp => 25000;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Fthagghua  ";
        public override bool TakeItem => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
