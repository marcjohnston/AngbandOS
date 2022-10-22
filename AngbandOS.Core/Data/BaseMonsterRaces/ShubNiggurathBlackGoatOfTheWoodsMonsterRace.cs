using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShubNiggurathBlackGoatOfTheWoodsMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Shub-Niggurath, Black Goat of the Woods";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 20;
        public override int Attack1DSides => 5;
        public override BaseAttackEffect? Attack1Effect => new LoseWisAttackEffect();
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 20;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new LoseIntAttackEffect();
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 2;
        public override BaseAttackEffect? Attack3Effect => new LoseStrAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 2;
        public override BaseAttackEffect? Attack4Effect => new LoseConAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool AttrAny => true;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheChaos => true;
        public override bool BreatheConfusion => true;
        public override bool BreathePoison => true;
        public override bool BreatheRadiation => true;
        public override bool CauseMortalWounds => true;
        public override bool ChaosBall => true;
        public override bool DarkBall => true;
        public override bool Demon => true;
        public override string Description => "This horrendous outer god looks like a writhing cloudy mass filled with mouths and tentacles.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shub-Niggurath, Black Goat of the Woods";
        public override bool GreatOldOne => true;
        public override int Hdice => 65;
        public override bool Heal => true;
        public override int Hside => 99;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 91;
        public override bool LightningAura => true;
        public override bool ManaBolt => true;
        public override int Mexp => 47500;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Shub-Niggura";
        public override bool SummonCthuloid => true;
        public override bool SummonHiUndead => true;
        public override bool SummonMonsters => true;
        public override bool SummonUnique => true;
        public override bool Unique => true;
    }
}
