using System.Threading;

namespace AngbandOS.Core.AttackTypes
{
    internal class CrawlAttackType : BaseAttackType
    {
        public override string MonsterAction(Monster monster) => $"crawls on {monster.Name}";
        public override string PlayerAction(SaveGame saveGame) => $"crawls on you";
        public override string KnowledgeAction => "crawl on you";
        public override bool RendersMissMessage => false;
    }
}
