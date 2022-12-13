using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TenguMonsterRace : MonsterRace
    {
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BlinkMonsterSpell(),
            new TeleportAwayMonsterSpell(),
            new TeleportToMonsterSpell(),
            new TeleportSelfMonsterSpell());
        public override char Character => 'u';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Tengu";

        public override int ArmourClass => 32;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a fast-moving demon that blinks quickly in and out of existence; no other demon matches its teleporting mastery.";
        public override bool Evil => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Tengu";
        public override int Hdice => 16;
        public override int Hside => 9;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override int LevelFound => 10;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool ResistTeleport => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Tengu    ";
    }
}
