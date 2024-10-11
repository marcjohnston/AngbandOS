export class GameConfiguration {
    public maxMessageLogLength: number | null = null;
    public startupTownName: string | null = null;
    public towns: TownGameConfiguration[] | null = null;
    public shopkeepers: ShopkeeperGameConfiguration[] | null = null;
    public gameCommands: GameCommandGameConfiguration[] | null = null;
    public storeCommands: StoreCommandGameConfiguration[] | null = null;
    public helpGroups: HelpGroupGameConfiguration[] | null = null;
    public monsterRaces: MonsterRaceGameConfiguration[] | null = null;
    public symbols: SymbolGameConfiguration[] | null = null;
    public vaults: VaultGameConfiguration[] | null = null;
    public dungeonGuardians: DungeonGuardianGameConfiguration[] | null = null;
    public dungeons: DungeonGameConfiguration[] | null = null;
    public storeFactories: StoreFactoryGameConfiguration[] | null = null;
    public projectileGraphics: ProjectileGraphicGameConfiguration[] | null = null;
    public amuletReadableFlavor: ReadableFlavorGameConfiguration[] | null = null;
    public mushroomReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public potionReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public ringReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public rodReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public scrollReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public staffReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public wandReadableFlavors: ReadableFlavorGameConfiguration[] | null = null;
    public classSpells: ClassSpellGameConfiguration[] | null = null;
    public wizardCommands: WizardCommandGameConfiguration[] | null = null;
    public tiles: TileGameConfiguration[] | null = null;
    public animations: AnimationGameConfiguration[] | null = null;
    public spells: SpellGameConfiguration[] | null = null;
    public plurals: PluralGameConfiguration[] | null = null;
    public attacks: AttackGameConfiguration[] | null = null;
    public gods: GodGameConfiguration[] | null = null;
    public elvishTexts: string[] | null = null;
    public findQuests: string[] | null = null;
    public funnyComments: string[] | null = null;
    public funnyDescriptions: string[] | null = null;
    public horrificDescriptions: string[] | null = null;
    public insultPlayerAttacks: string[] | null = null;
    public moanPlayerAttacks: string[] | null = null;
    public unreadableFlavorSyllables: string[] | null = null;
    public shopkeeperAcceptedComments: string[] | null = null;
    public shopkeeperBargainComments: string[] | null = null;
    public shopkeeperGoodComments: string[] | null = null;
    public shopkeeperLessThanGuessComments: string[] | null = null;
    public shopkeeperWorthlessComments: string[] | null = null;
    public singingPlayerAttacks: string[] | null = null;
    public worshipPlayerAttacks: string[] | null = null;
}

export class AnimationGameConfiguration { }
export class AttackGameConfiguration { }
export class ClassSpellGameConfiguration { }
export class DungeonGameConfiguration { }
export class DungeonGuardianGameConfiguration { }
export class GameCommandGameConfiguration { }
export class GodGameConfiguration { }
export class HelpGroupGameConfiguration { }
export class MonsterRaceGameConfiguration { }
export class PluralGameConfiguration { }
export class ProjectileGraphicGameConfiguration { }
export class ReadableFlavorGameConfiguration { }
export class ShopkeeperGameConfiguration { }
export class SpellGameConfiguration { }
export class StoreCommandGameConfiguration { }
export class StoreFactoryGameConfiguration { }
export class SymbolGameConfiguration { }
export class TileGameConfiguration { }
export class TownGameConfiguration { }
export class VaultGameConfiguration { }
export class WizardCommandGameConfiguration { }
