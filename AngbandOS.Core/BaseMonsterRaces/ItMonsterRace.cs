using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ItMonsterRace : Base2MonsterRace
    {
        public override char Character => '·';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "It";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 8;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new BlindAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new TerrifyAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new Exp40AttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new EatItemAttackEffect();
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool AttrClear => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool CharClear => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool CreateTraps => true;
        public override bool Darkness => true;
        public override string Description => "Nobody has ever seen It.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool Forget => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "It";
        public override int Hdice => 77;
        public override bool Heal => true;
        public override int Hside => 9;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 24;
        public override int Mexp => 400;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override bool Shriek => true;
        public override int Sleep => 25;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "     It     ";
        public override bool SummonHydra => true;
        public override bool SummonMonster => true;
        public override bool SummonUndead => true;
        public override bool TeleportAway => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
