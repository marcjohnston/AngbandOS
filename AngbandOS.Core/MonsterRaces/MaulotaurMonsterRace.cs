using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MaulotaurMonsterRace : MonsterRace
    {
        protected MaulotaurMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new FireBallMonsterSpell(),
            new FireBoltMonsterSpell(),
            new PlasmaBoltMonsterSpell());
        public override char Character => 'H';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Maulotaur";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Hit, new ShatterAttackEffect(), 5, 6),
            new MonsterAttack(AttackType.Hit, new ShatterAttackEffect(), 5, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "It is a belligrent minotaur with some destructive magical arsenal, armed with a hammer.";
        public override bool Drop60 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Maulotaur";
        public override int Hdice => 250;
        public override int Hside => 10;
        public override bool ImmuneFire => true;
        public override int LevelFound => 50;
        public override int Mexp => 4500;
        public override int NoticeRange => 13;
        public override bool OnlyDropItem => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Maulotaur  ";
        public override bool Stupid => true;
    }
}
