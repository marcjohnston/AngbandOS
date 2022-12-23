using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FthagghuaLordOfTheFireVampiresMonsterRace : MonsterRace
    {
        protected FthagghuaLordOfTheFireVampiresMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheFireMonsterSpell(),
            new BlindnessMonsterSpell(),
            new FireBallMonsterSpell(),
            new FireBoltMonsterSpell(),
            new ManaBoltMonsterSpell(),
            new TeleportToMonsterSpell());
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Fthagghua, Lord of the fire vampires";

        public override int ArmourClass => 160;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 9, 12),
            new MonsterAttack(AttackType.Hit, new FireAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Engulf, new FireAttackEffect(), 10, 10),
            new MonsterAttack(AttackType.Engulf, new HurtAttackEffect(), 10, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "A fiery serpentine entity, streaking through the air like a comet. The heat emanating from this creature is almost unbearable.";
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool FireAura => true;
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
        public override int LevelFound => 56;
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
        public override bool Unique => true;
    }
}
