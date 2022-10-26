using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ServitorOfTheOuterGodsMonsterRace : Base2MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Servitor of the outer gods";

        public override int ArmourClass => 140;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 8, 6),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseMortalWounds => true;
        public override bool CauseSeriousWounds => true;
        public override bool Cthuloid => true;
        public override string Description => "'Toad - like creatures which seemed constantly to be changing shape and appearance, and from whom emanated, by some means I could not distinguish, a ghostly ululation, a piping.' August Derleth - 'The Lurker at The Threshold'.";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Servitor of the outer gods";
        public override int Hdice => 100;
        public override int Hside => 35;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int Level => 41;
        public override bool ManaBolt => true;
        public override int Mexp => 15000;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 6;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "Servitor of ";
        public override string SplitName2 => " the outer  ";
        public override string SplitName3 => "    gods    ";
        public override bool SummonCthuloid => true;
        public override bool SummonUndead => true;
        public override bool TakeItem => true;
        public override bool TeleportTo => true;
    }
}
