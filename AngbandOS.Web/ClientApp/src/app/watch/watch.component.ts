import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

const charSize = 12;
enum Colour {
  Background = 0,
  Black = 1,
  Grey = 2,
  BrightGrey = 3,
  Silver = 4,
  Beige = 5,
  BrightBeige = 6,
  White = 7,
  BrightWhite = 8,
  Red = 9,
  BrightRed = 10,
  Copper = 11,
  Orange = 12,
  BrightOrange = 13,
  Brown = 14,
  BrightBrown = 15,
  Gold = 16,
  Yellow = 17,
  BrightYellow = 18,
  Chartreuse = 19,
  BrightChartreuse = 20,
  Green = 21,
  BrightGreen = 22,
  Turquoise = 23,
  BrightTurquoise = 24,
  Blue = 25,
  BrightBlue = 26,
  Diamond = 27,
  Purple = 28,
  BrightPurple = 29,
  Pink = 30,
  BrightPink = 31,
}

enum SoundEffect {
  EnterTownDay = 0,
  EnterTownNight = 1,
  EnterDungeon1 = 2,
  EnterDungeon2 = 3,
  EnterDungeon3 = 4,
  EnterDungeon4 = 5,
  EnterDungeon5 = 6,
  StoreSoldWorthless = 7,
  StoreSoldBargain = 8,
  StoreSoldCheaply = 9,
  StoreSoldExtraCheaply = 10,
  StoreTransaction = 11,
  EnterStore = 12,
  LeaveStore = 13,
  MeleeHit = 14,
  HitGood = 15,
  HitGreat = 16,
  HitSuperb = 17,
  HitHiGreat = 18,
  HitHiSuperb = 19,
  Miss = 20,
  Shoot = 21,
  RangedHit = 22,
  HealthWarning = 23,
  PlayerDeath = 24,
  PlayerBlind = 25,
  Playerconfused = 26,
  PlayerPoisoned = 27,
  PlayerAfraid = 28,
  PlayerParalysed = 29,
  PlayerDrugged = 30,
  PlayerSlow = 31,
  PlayerCut = 32,
  PlayerStatDrain = 33,
  PlayerRecover = 34,
  PlayerHaste = 35,
  PlayerShield = 36,
  PlayerBlessed = 37,
  PlayerHeroism = 38,
  PlayerBerserk = 39,
  PlayerProtEvil = 40,
  PlayerInvulnerable = 41,
  PlayerSeeInvisible = 42,
  PlayerInfravision = 43,
  PlayerResistAcid = 44,
  PlayerResistElectric = 45,
  PlayerResistFire = 46,
  PlayerResistCold = 47,
  PlayerResistPoison = 48,
  Hungry = 49,
  PickUpMoney1 = 50,
  PickUpMoney2 = 51,
  PickUpMoney3 = 52,
  Drop = 53,
  LevelGain = 54,
  Study = 55,
  Teleport = 56,
  Quaff = 57,
  ZapRod = 58,
  BumpWall = 59,
  Eat = 60,
  Dig = 61,
  OpenDoor = 62,
  ShutDoor = 63,
  TeleportLevel = 64,
  Bell = 65,
  NothingToOpen = 66,
  LockpickFail = 67,
  LockpickSuccess = 68,
  DisarmTrap = 69,
  StairsUp = 70,
  StairsDown = 71,
  ActivateArtifact = 72,
  UseStaff = 73,
  DestroyItem = 74,
  WieldWeapon = 75,
  Cursed = 76,
  FindSecretDoor = 77,
  PseudoId = 78,
  CastSpell = 79,
  Pray = 80,
  MonsterFlees = 81,
  MonsterDies = 82,
  UniqueDies = 83,
  QuestMonsterDies = 84,
  MonsterHits = 85,
  MonsterTouches = 86,
  MonsterBashes = 87,
  MonsterKicks = 88,
  MonsterClaws = 89,
  MonsterBites = 90,
  MonsterStings = 91,
  MonsterButts = 92,
  MonsterCrushes = 93,
  MonsterEngulfs = 94,
  MonsterCrawls = 95,
  MonsterDrools = 96,
  MonsterSpits = 97,
  MonsterGazes = 98,
  MonsterWails = 99,
  MonsterSpores = 100,
  MonsterBegs = 101,
  MonsterInsults = 102,
  MonsterMoans = 103,
  MonsterShrieks = 104,
  MonsterCreatesTraps = 105,
  MonsterCausesFear = 106,
  MonsterBreeds = 107,
  SummonMonster = 108,
  SummonAngel = 109,
  SummonUndead = 110,
  SummonAnimals = 111,
  SummonSpiders = 112,
  SummonHounds = 113,
  SummonHydras = 114,
  SummonDemons = 115,
  SummonDragons = 116,
  SummonGreaterUndead = 117,
  SummonGreaterDragons = 118,
  SummonGreaterDemons = 119,
  SummonRingwraiths = 120,
  SummonUniques = 121,
  BreathWeapon = 122,
  IdentifyBad = 123,
  IdentifyGood = 124,
  IdentifySpecial = 125
}

@Component({
  selector: 'app-watch',
  templateUrl: './watch.component.html',
  styleUrls: [
    './watch.component.scss'
  ]
})
export class WatchComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  private connection: SignalR.HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _sounds = new Map<SoundEffect, string[]>();
  private _colours = new Map<Colour, string>();

  constructor(
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _zone: NgZone
  ) {
  }

  public charSize(): number {
    return charSize;
  }

  private check() {
    if (this.connection !== undefined && this.gameGuid !== null) {
    }
  }

  private updateCanvasSize() {
    if (this.canvasRef) {
      const canvas: HTMLCanvasElement = this.canvasRef.nativeElement;
      canvas.width = 80 * charSize;
      canvas.height = 45 * charSize;
      canvas.style.minWidth = canvas.width + "px";
      canvas.style.maxWidth = canvas.width + "px";
      canvas.style.minHeight = canvas.height + "px";
      canvas.style.maxHeight = canvas.height + "px";
    }
  }

  private setupColorMap() {
    this._colours.set(Colour.Background, "#000000");
    this._colours.set(Colour.Black, "#F2F4F4F");
    this._colours.set(Colour.Grey, "#696969");
    this._colours.set(Colour.BrightGrey, "#A9A9A9");
    this._colours.set(Colour.Silver, "#778899");
    this._colours.set(Colour.Beige, "#FFE4B5");
    this._colours.set(Colour.BrightBeige, "#F5F5DC");
    this._colours.set(Colour.White, "#D3D3D3");
    this._colours.set(Colour.BrightWhite, "#FFFFFF");
    this._colours.set(Colour.Red, "#8B0000");
    this._colours.set(Colour.BrightRed, "#FF0000");
    this._colours.set(Colour.Copper, "#D2691E");
    this._colours.set(Colour.Orange, "#FF4500");
    this._colours.set(Colour.BrightOrange, "#FFA500");
    this._colours.set(Colour.Brown, "#8B4513");
    this._colours.set(Colour.BrightBrown, "#DEB887");
    this._colours.set(Colour.Gold, "#FFD700");
    this._colours.set(Colour.Yellow, "#F0E68C");
    this._colours.set(Colour.BrightYellow, "#FFFF00");
    this._colours.set(Colour.Chartreuse, "#9ACD32");
    this._colours.set(Colour.BrightChartreuse, "#7FFF00");
    this._colours.set(Colour.Green, "#006400");
    this._colours.set(Colour.BrightGreen, "#32CD32");
    this._colours.set(Colour.Turquoise, "#00CED1");
    this._colours.set(Colour.BrightTurquoise, "#00FFFF");
    this._colours.set(Colour.Blue, "#0000CD");
    this._colours.set(Colour.BrightBlue, "#00BFFF");
    this._colours.set(Colour.Diamond, "#E0FFFF");
    this._colours.set(Colour.Purple, "#800080");
    this._colours.set(Colour.BrightPurple, "#EE82EE");
    this._colours.set(Colour.Pink, "#FF1493");
    this._colours.set(Colour.BrightPink, "#FF69B4");
  }

  private setupSounds() {
    this._sounds.set(SoundEffect.ActivateArtifact, ["plm_aim_wand.wav"]);
    this._sounds.set(SoundEffect.Bell, ["plm_jar_ding.wav"]);
    this._sounds.set(SoundEffect.BreathWeapon, ["mco_attack_breath.wav"]);
    this._sounds.set(SoundEffect.BumpWall, ["plm_wood_thud.wav"]);
    this._sounds.set(SoundEffect.CastSpell, ["plm_spell1.wav", "plm_spell2.wav", "plm_spell3.wav"]);
    this._sounds.set(SoundEffect.Cursed, ["pls_man_oooh.wav"]);
    this._sounds.set(SoundEffect.DestroyItem, ["plm_bang_metal.wav", "plm_break_canister.wav", "plm_break_glass.wav", "plm_break_glass2.wav", "plm_break_plates.wav", "plm_break_shatter.wav", "plm_break_smash.wav", "plm_glass_breaking.wav", "plm_glass_break.wav", "plm_glass_smashing.wav"]);
    this._sounds.set(SoundEffect.Dig, ["plm_metal_clank.wav"]);
    this._sounds.set(SoundEffect.DisarmTrap, ["plm_bang_ceramic.wav", "plm_chest_latch.wav", "plm_click_switch3.wav"]);
    this._sounds.set(SoundEffect.Drop, ["plm_drop_boot.wav"]);
    this._sounds.set(SoundEffect.Eat, ["plm_eat_bite.wav"]);
    this._sounds.set(SoundEffect.EnterDungeon1, ["amb_door_iron.wav", "amb_bell_metal1.wav"]);
    this._sounds.set(SoundEffect.EnterDungeon2, ["amb_bell_tibet1.wav", "amb_bell_metal2.wav", "amb_gong_strike.wav"]);
    this._sounds.set(SoundEffect.EnterDungeon3, ["amb_bell_tibet2.wav", "amb_dungeon_echo.wav", "amb_pulse_low.wav"]);
    this._sounds.set(SoundEffect.EnterDungeon4, ["amb_bell_tibet3.wav", "amb_dungeon_echowet.wav", "amb_gong_undertone.wav"]);
    this._sounds.set(SoundEffect.EnterDungeon5, ["amb_door_doom.wav", "amb_gong_chinese.wav", "amb_gong_low.wav"]);
    this._sounds.set(SoundEffect.EnterStore, ["sto_bell_desk.wav", "sto_bell_ding.wav", "sto_bell_dingaling.wav", "sto_bell_jingles.wav", "sto_bell_ringing.wav", "sto_bell_shop.wav"]);
    this._sounds.set(SoundEffect.EnterTownDay, ["amb_thunder_rain.wav"]);
    this._sounds.set(SoundEffect.EnterTownNight, ["amb_guitar_chord.wav", "amb_thunder_roll.wav"]);
    this._sounds.set(SoundEffect.FindSecretDoor, ["id_bad_hmm.wav"]);
    this._sounds.set(SoundEffect.HealthWarning, ["plc_bell_warn.wav"]);
    this._sounds.set(SoundEffect.HitGood, ["plc_hit_anvil.wav"]);
    this._sounds.set(SoundEffect.HitGreat, ["plc_hit_groan.wav"]);
    this._sounds.set(SoundEffect.HitHiGreat, ["plc_hit_grunt.wav"]);
    this._sounds.set(SoundEffect.HitHiSuperb, ["plc_hit_anvil2.wav"]);
    this._sounds.set(SoundEffect.HitSuperb, ["plc_hit_grunt2.wav"]);
    this._sounds.set(SoundEffect.Hungry, ["id_bad_hmm.wav"]);
    this._sounds.set(SoundEffect.IdentifyBad, ["id_bad_hmm.wav"]);
    this._sounds.set(SoundEffect.IdentifyGood, ["id_bad_hmm.wav"]);
    this._sounds.set(SoundEffect.IdentifySpecial, ["id_bad_hmm.wav"]);
    this._sounds.set(SoundEffect.LeaveStore, ["plm_door_bolt.wav"]);
    this._sounds.set(SoundEffect.LevelGain, ["plm_levelup.wav"]);
    this._sounds.set(SoundEffect.LockpickFail, ["plm_click_dry.wav", "plm_click_switch.wav", "plm_click_wood.wav", "plm_door_echolock.wav", "plm_door_wooden.wav"]);
    this._sounds.set(SoundEffect.LockpickSuccess, ["plm_break_wood.wav", "plm_cabinet_open.wav", "plm_chest_unlatch.wav", "plm_lock_case.wav", "plm_lock_distant.wav", "plm_open_case.wav"]);
    this._sounds.set(SoundEffect.MeleeHit, ["plc_hit_hay.wav", "plc_hit_body.wav"]);
    this._sounds.set(SoundEffect.Miss, ["plc_miss_arrow2.wav"]);
    this._sounds.set(SoundEffect.MonsterBashes, ["mco_squish_snap.wav"]);
    this._sounds.set(SoundEffect.MonsterBegs, ["mco_man_mumble.wav"]);
    this._sounds.set(SoundEffect.MonsterBites, ["mco_snarl_short.wav", "mco_bite_soft.wav", "mco_bite_munch.wav", "mco_bite_long.wav", "mco_bite_short.wav", "mco_bite_gnash.wav", "mco_bite_chomp.wav", "mco_bite_regular.wav", "mco_bite_small.wav", "mco_bite_dainty.wav", "mco_bite_hard.wav", "mco_bite_chew.wav"]);
    this._sounds.set(SoundEffect.MonsterBreeds, ["mco_frog_trill.wav"]);
    this._sounds.set(SoundEffect.MonsterButts, ["mco_cuica_rubbing.wav", "mco_thud_crash.wav"]);
    this._sounds.set(SoundEffect.MonsterCausesFear, ["mco_creature_groan.wav", "mco_dino_slur.wav"]);
    this._sounds.set(SoundEffect.MonsterClaws, ["mco_ceramic_trill.wav", "mco_scurry_dry.wav"]);
    this._sounds.set(SoundEffect.MonsterCrawls, ["mco_card_shuffle.wav", "mco_shake_roll.wav"]);
    this._sounds.set(SoundEffect.MonsterCreatesTraps, ["mco_thoing_deep.wav"]);
    this._sounds.set(SoundEffect.MonsterCrushes, ["mco_dino_low.wav", "mco_squish_hit.wav"]);
    this._sounds.set(SoundEffect.MonsterDies, ["mco_howl_croak.wav", "mco_howl_deep.wav", "mco_howl_distressed.wav", "mco_howl_high.wav", "mco_howl_long.wav"]);
    this._sounds.set(SoundEffect.MonsterDrools, ["mco_creature_choking.wav", "mco_liquid_squirt.wav"]);
    this._sounds.set(SoundEffect.MonsterEngulfs, ["mco_dino_talk.wav", "mco_dino_yawn.wav"]);
    this._sounds.set(SoundEffect.MonsterFlees, ["mco_creature_yelp.wav"]);
    this._sounds.set(SoundEffect.MonsterGazes, ["mco_thoing_backwards.wav"]);
    this._sounds.set(SoundEffect.MonsterHits, ["mco_hit_whip.wav"]);
    this._sounds.set(SoundEffect.MonsterInsults, ["mco_strange_thwoink.wav"]);
    this._sounds.set(SoundEffect.MonsterKicks, ["mco_rubber_thud.wav"]);
    this._sounds.set(SoundEffect.MonsterMoans, ["mco_strange_music.wav"]);
    this._sounds.set(SoundEffect.MonsterShrieks, ["mco_mouse_squeaks.wav"]);
    this._sounds.set(SoundEffect.MonsterSpits, ["mco_attack_spray.wav"]);
    this._sounds.set(SoundEffect.MonsterSpores, ["mco_dub_wobble.wav", "mco_spray_long.wav"]);
    this._sounds.set(SoundEffect.MonsterStings, ["mco_castanet_trill.wav", "mco_tube_hit.wav"]);
    this._sounds.set(SoundEffect.MonsterTouches, ["mco_click_vibra.wav"]);
    this._sounds.set(SoundEffect.MonsterWails, ["mco_dino_low.wav"]);
    this._sounds.set(SoundEffect.NothingToOpen, ["plm_click_switch2.wav", "plm_door_knob.wav"]);
    this._sounds.set(SoundEffect.OpenDoor, ["plm_door_bolt.wav", "plm_door_creak.wav", "plm_door_dungeon.wav", "plm_door_entrance.wav", "plm_door_open.wav", "plm_door_opening.wav", "plm_door_rusty.wav", "plm_door_squeaky.wav"]);
    this._sounds.set(SoundEffect.PickUpMoney1, ["plm_coins_light.wav", "plm_coins_shake.wav"]);
    this._sounds.set(SoundEffect.PickUpMoney2, ["plm_chain_light.wav", "plm_coins_pour.wav"]);
    this._sounds.set(SoundEffect.PickUpMoney3, ["plm_coins_dump.wav"]);
    this._sounds.set(SoundEffect.PlayerAfraid, ["pls_man_yell.wav"]);
    this._sounds.set(SoundEffect.PlayerBerserk, ["pls_man_scream2.wav"]);
    this._sounds.set(SoundEffect.PlayerBlessed, ["sum_angel_song.wav"]);
    this._sounds.set(SoundEffect.PlayerBlind, ["pls_tone_conk.wav"]);
    this._sounds.set(SoundEffect.Playerconfused, ["pls_man_ugh.wav"]);
    this._sounds.set(SoundEffect.PlayerCut, ["pls_man_argoh.wav"]);
    this._sounds.set(SoundEffect.PlayerDeath, ["plc_die_laugh.wav"]);
    this._sounds.set(SoundEffect.PlayerDrugged, ["pls_breathe_in.wav"]);
    this._sounds.set(SoundEffect.PlayerHaste, ["pls_bell_sustain.wav"]);
    this._sounds.set(SoundEffect.PlayerHeroism, ["pls_tone_goblet.wav"]);
    this._sounds.set(SoundEffect.PlayerInfravision, ["pls_tone_clavelo8.wav"]);
    this._sounds.set(SoundEffect.PlayerInvulnerable, ["pls_tone_blurk.wav"]);
    this._sounds.set(SoundEffect.PlayerParalysed, ["pls_man_gulp_new.wav"]);
    this._sounds.set(SoundEffect.PlayerPoisoned, ["pls_tone_guiro.wav"]);
    this._sounds.set(SoundEffect.PlayerProtEvil, ["pls_bell_glass.wav"]);
    this._sounds.set(SoundEffect.PlayerRecover, ["pls_bell_chime_new.wav"]);
    this._sounds.set(SoundEffect.PlayerResistAcid, ["pls_man_sniff.wav"]);
    this._sounds.set(SoundEffect.PlayerResistCold, ["pls_tone_stick.wav"]);
    this._sounds.set(SoundEffect.PlayerResistElectric, ["pls_tone_elec.wav"]);
    this._sounds.set(SoundEffect.PlayerResistFire, ["pls_tone_scrape.wav"]);
    this._sounds.set(SoundEffect.PlayerResistPoison, ["pls_man_spit.wav"]);
    this._sounds.set(SoundEffect.PlayerSeeInvisible, ["pls_tone_clave6.wav"]);
    this._sounds.set(SoundEffect.PlayerShield, ["pls_bell_bowl.wav"]);
    this._sounds.set(SoundEffect.PlayerSlow, ["pls_man_sigh.wav"]);
    this._sounds.set(SoundEffect.PlayerStatDrain, ["pls_tone_headstock.wav"]);
    this._sounds.set(SoundEffect.Pray, ["sum_angel_song.wav"]);
    this._sounds.set(SoundEffect.PseudoId, ["id_good_hmm.wav"]);
    this._sounds.set(SoundEffect.Quaff, ["plm_bottle_clinks.wav", "plm_cork_pop.wav", "plm_cork_squeak.wav"]);
    this._sounds.set(SoundEffect.QuestMonsterDies, ["amb_guitar_chord.wav"]);
    this._sounds.set(SoundEffect.RangedHit, ["plc_hit_arrow.wav"]);
    this._sounds.set(SoundEffect.Shoot, ["plc_miss_swish.wav", "plc_miss_arrow.wav"]);
    this._sounds.set(SoundEffect.ShutDoor, ["plm_bang_dumpster.wav", "plm_cabinet_shut.wav", "plm_close_hatch.wav", "plm_door_creakshut.wav", "plm_door_latch.wav", "plm_door_shut.wav", "plm_door_slam.wav"]);
    this._sounds.set(SoundEffect.StairsDown, ["plm_floor_creak.wav"]);
    this._sounds.set(SoundEffect.StairsUp, ["plm_floor_creak2.wav"]);
    this._sounds.set(SoundEffect.StoreSoldBargain, ["id_bad_dang.wav"]);
    this._sounds.set(SoundEffect.StoreSoldCheaply, ["sto_man_haha.wav"]);
    this._sounds.set(SoundEffect.StoreSoldExtraCheaply, ["sto_man_whoohaha.wav"]);
    this._sounds.set(SoundEffect.StoreSoldWorthless, ["sto_man_hey.wav"]);
    this._sounds.set(SoundEffect.StoreTransaction, ["sto_coins_countertop.wav", "sto_bell_register1.wav", "sto_bell_register2.wav"]);
    this._sounds.set(SoundEffect.Study, ["plm_book_pageturn.wav"]);
    this._sounds.set(SoundEffect.SummonAngel, ["sum_angel_song.wav"]);
    this._sounds.set(SoundEffect.SummonAnimals, ["sum_lion_growl.wav"]);
    this._sounds.set(SoundEffect.SummonDemons, ["sum_ghost_wail.wav", "sum_laugh_evil2.wav"]);
    this._sounds.set(SoundEffect.SummonDragons, ["sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffect.SummonGreaterDemons, ["sum_ghost_moan.wav"]);
    this._sounds.set(SoundEffect.SummonGreaterDragons, ["sum_gong_temple.wav"]);
    this._sounds.set(SoundEffect.SummonGreaterUndead, ["sum_ghost_moan.wav"]);
    this._sounds.set(SoundEffect.SummonHounds, ["sum_lion_growl.wav"]);
    this._sounds.set(SoundEffect.SummonHydras, ["sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffect.SummonMonster, ["sum_chime_jangle.wav"]);
    this._sounds.set(SoundEffect.SummonRingwraiths, ["sum_bell_hand.wav"]);
    this._sounds.set(SoundEffect.SummonSpiders, ["sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffect.SummonUndead, ["sum_ghost_oooo.wav"]);
    this._sounds.set(SoundEffect.SummonUniques, ["sum_bell_tone.wav"]);
    this._sounds.set(SoundEffect.Teleport, ["plm_chimes_jangle.wav"]);
    this._sounds.set(SoundEffect.TeleportLevel, ["sum_bell_crystal.wav"]);
    this._sounds.set(SoundEffect.UniqueDies, ["sum_ghost_wail.wav"]);
    this._sounds.set(SoundEffect.UseStaff, ["plm_use_staff.wav"]);
    this._sounds.set(SoundEffect.WieldWeapon, ["plm_metal_sharpen.wav"]);
    this._sounds.set(SoundEffect.ZapRod, ["plm_zap_rod.wav"]);
  }

  ngOnInit() {
    this.setupSounds();
    this.setupColorMap();

    // Create the signal-r connection object.
    this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/spectators-hub").build();

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap: ParamMap) => {
      this.gameGuid = paramMap.get("guid");

      if (this.connection !== undefined) {
        this.connection.start().then(() => {
          if (this.connection) {
            this.connectionId = this.connection.connectionId; // This is needed to render on the screen.

            this.connection.on("SetCellBackground", (row: number, col: number, c: string, color: Colour) => {
              this._zone.run(() => {
                if (this.canvasRef) {
                  const canvas = this.canvasRef.nativeElement;
                  const context: CanvasRenderingContext2D = canvas.getContext('2d');
                  context.fillStyle = `#FF0000`; // Rd background
                  context.fillRect(col * charSize, row * charSize, charSize, charSize);
                  context.textBaseline = 'top';
                  context.textAlign = 'left';
                  const rgbColor = this._colours.get(color);
                  context.fillStyle = `${rgbColor}`;
                  context.font = `${charSize}px Courier`;
                  context.fillText(c, col * charSize, row * charSize);
                }
              });
            });
            this.connection.on("UnsetCellBackground", (row: number, col: number, c: string, color: Colour) => {
              this._zone.run(() => {
                if (this.canvasRef) {
                  const canvas = this.canvasRef.nativeElement;
                  const context: CanvasRenderingContext2D = canvas.getContext('2d');
                  context.fillStyle = `#000000`; // Rd background
                  context.fillRect(col * charSize, row * charSize, charSize, charSize);
                  context.textBaseline = 'top';
                  context.textAlign = 'left';
                  const rgbColor = this._colours.get(color);
                  context.fillStyle = `${rgbColor}`;
                  context.font = `${charSize}px Courier`;
                  context.fillText(c, col * charSize, row * charSize);
                }
              });
            });
            this.connection.on("Clear", () => {
              this._zone.run(() => {
                if (this.canvasRef !== undefined) {
                  const canvas = this.canvasRef.nativeElement;
                  var dpr = window.devicePixelRatio || 1;
                  var rect = canvas.getBoundingClientRect();
                  const context: CanvasRenderingContext2D = canvas.getContext('2d');
                  context.clearRect(0, 0, rect.width, rect.height);
                }
              });
            });
            this.connection.on("Print", (row: number, col: number, text: string, color: Colour) => {
              this._zone.run(() => {
                if (this.canvasRef !== undefined) {
                  const canvas = this.canvasRef.nativeElement;
                  canvas.style.width = 1440;
                  canvas.style.height = 810;
                  const context: CanvasRenderingContext2D = canvas.getContext('2d');
                  context.clearRect(col * charSize, row * charSize, text.length * charSize, charSize);
                  context.textBaseline = 'top';
                  context.textAlign = 'left';
                  const rgbColor = this._colours.get(color);
                  context.fillStyle = `${rgbColor}`;
                  context.font = `${charSize}px Courier`;
                  for (var i: number = 0; i < text.length; i++) {
                    const c = text[i];
                    context.fillText(c, col * charSize, row * charSize);
                    col++;
                  }
                }
              });
            });
            this.connection.on("SetBackground", (backgroundImage: number) => {
              this._zone.run(() => {
              });
            });
            this.connection.on("PlaySound", (sound: number) => {
              this._zone.run(() => {
              });
            });
            this.connection.on("PlayMusic", (music: number) => {
              this._zone.run(() => {
              });
            });
            this.connection.on("GameOver", () => {
              this._router.navigate(['/']);
            });

            this.connection.send("watch", this.gameGuid);
          }
        }, () => {
          this._snackBar.open("Connection to game server failed.", undefined, {
            duration: 2000,
          });
          this._router.navigate(['/']);
        });
      }
    }));
    this.updateCanvasSize();
  }

  ngOnDestroy() {
    if (this.connection) {
      this.connection.off("UnsetCellBackground");
      this.connection.off("SetCellBackground");
      this.connection.off("Clear");
      this.connection.off("Print");
      this.connection.off("SetBackground");
      this.connection.off("PlaySound");
      this.connection.off("PlayMusic");
      this.connection.off("GameOver");
      this.connection.stop();
      this._initSubscriptions.unsubscribe();
    }
  }
}
