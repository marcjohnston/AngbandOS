using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheCollectorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Copper;
        public override string Name => "The Collector";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override BaseAttackEffect? Attack1Effect => new LoseChaAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new EatItemAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 1;
        public override BaseAttackEffect? Attack3Effect => new LoseAllAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new EatGoldAttackEffect();
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override bool CreateTraps => true;
        public override string Description => "A strange little gnome, he's been collecting toys and friends and doesn't want to give them up.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "The Collector";
        public override int Hdice => 25;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool ImmuneStun => true;
        public override int Level => 52;
        public override bool Male => true;
        public override int Mexp => 45000;
        public override bool NetherBall => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 150;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    The     ";
        public override string SplitName3 => " Collector  ";
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonUndead => true;
        public override bool SummonUnique => true;
        public override bool TeleportAway => true;
        public override bool Unique => true;
    }
}
