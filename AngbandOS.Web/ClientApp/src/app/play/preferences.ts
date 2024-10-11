/// <summary>
/// Represents the current user preferences.
/// </summary>
export class Preferences {
  public fontName: string | null = null;
  public fontSize: number | null = null;
  public f1Macro: string | null = null;
  public f2Macro: string | null = null;
  public f3Macro: string | null = null;
  public f4Macro: string | null = null;
  public f5Macro: string | null = null;
  public f6Macro: string | null = null;
  public f7Macro: string | null = null;
  public f8Macro: string | null = null;
  public f9Macro: string | null = null;
  public f10Macro: string | null = null;
  public f11Macro: string | null = null;
  public f12Macro: string | null = null;
}

export class GConfig {
  public test: number = 5;
}

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
  public wizardCommands: WizardCommandGameConfiguration[]  | null = null;
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
export class TownGameConfiguration { }
export class ShopkeeperGameConfiguration { }
export class GameCommandGameConfiguration { }
export class StoreCommandGameConfiguration { }
export class HelpGroupGameConfiguration { }
export class MonsterRaceGameConfiguration { }
export class SymbolGameConfiguration { }
export class VaultGameConfiguration { }
export class DungeonGuardianGameConfiguration { }
export class DungeonGameConfiguration { }
export class StoreFactoryGameConfiguration { }
export class ProjectileGraphicGameConfiguration { }
export class ReadableFlavorGameConfiguration { }
export class ClassSpellGameConfiguration { }
export class WizardCommandGameConfiguration { }
export class TileGameConfiguration { }
export class AnimationGameConfiguration { }
export class SpellGameConfiguration { }
export class PluralGameConfiguration { }
export class AttackGameConfiguration { }
export class GodGameConfiguration { }

