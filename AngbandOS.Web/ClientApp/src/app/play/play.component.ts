import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ColourEnum } from '../modules/colour-enum/colour-enum.module';
import { SoundEffectsEnum } from '../modules/sound-effects-enum/sound-effects-enum.module';

const charSize = 12;

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: [
    './play.component.scss'
  ]
})
export class PlayComponent implements OnInit, OnDestroy {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  private connection: SignalR.HubConnection | undefined;
  public connectionId: string | null = null;
  public gameGuid: string | null | undefined = undefined; // Represents the unique identifier for the game to play; null, to start a new game; otherwise, undefined when the guid hasn't been retrieved yet.
  private _initSubscriptions = new Subscription();
  private _sounds = new Map<SoundEffectsEnum, string[]>();
  private _colours = new Map<ColourEnum, string>();

  constructor(
    private _httpClient: HttpClient,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private _authenticationService: AuthenticationService,
    private _zone: NgZone
  ) {
  }

  @HostListener('window:keydown', ['$event'])
  public onKeyDown(event: KeyboardEvent) {
    if (this.connection) {
      const shift: string = (event.shiftKey ? "." : "");
      switch (event.key) {
        case "ArrowLeft":
          this.connection.send("keypressed", `${shift}4`);
          break;
        case "ArrowRight":
          this.connection.send("keypressed", `${shift}6`);
          break;
        case "ArrowUp":
          this.connection.send("keypressed", `${shift}8`);
          break;
        case "ArrowDown":
          this.connection.send("keypressed", `${shift}2`);
          break;
        case "Home":
          this.connection.send("keypressed", `${shift}7`);
          break;
        case "End":
          this.connection.send("keypressed", `${shift}1`);
          break;
        case "PageUp":
          this.connection.send("keypressed", `${shift}9`);
          break;
        case "PageDown":
          this.connection.send("keypressed", `${shift}3`);
          break;
        case "Enter":
          this.connection.send("keypressed", '\x0D');
          break;
        case "Tab":
          this.connection.send("keypressed", '\x09');
          break;
        case "Escape":
          this.connection.send("keypressed", '\x1B');
          break;
        case "Backspace":
          this.connection.send("keypressed", '\x08');
          break;
        case "Control":
        case "Alt":
        case "Shift":
          break;
        default:
          this.connection.send("keypressed", event.key);
          break;
      }
    }
  }

  public get charSize(): number {
    return charSize;
  }

  private setupColorMap() {
    this._colours.set(ColourEnum.Background, "#000000");
    this._colours.set(ColourEnum.Black, "#F2F4F4F");
    this._colours.set(ColourEnum.Grey, "#696969");
    this._colours.set(ColourEnum.BrightGrey, "#A9A9A9");
    this._colours.set(ColourEnum.Silver, "#778899");
    this._colours.set(ColourEnum.Beige, "#FFE4B5");
    this._colours.set(ColourEnum.BrightBeige, "#F5F5DC");
    this._colours.set(ColourEnum.White, "#D3D3D3");
    this._colours.set(ColourEnum.BrightWhite, "#FFFFFF");
    this._colours.set(ColourEnum.Red, "#8B0000");
    this._colours.set(ColourEnum.BrightRed, "#FF0000");
    this._colours.set(ColourEnum.Copper, "#D2691E");
    this._colours.set(ColourEnum.Orange, "#FF4500");
    this._colours.set(ColourEnum.BrightOrange, "#FFA500");
    this._colours.set(ColourEnum.Brown, "#8B4513");
    this._colours.set(ColourEnum.BrightBrown, "#DEB887");
    this._colours.set(ColourEnum.Gold, "#FFD700");
    this._colours.set(ColourEnum.Yellow, "#F0E68C");
    this._colours.set(ColourEnum.BrightYellow, "#FFFF00");
    this._colours.set(ColourEnum.Chartreuse, "#9ACD32");
    this._colours.set(ColourEnum.BrightChartreuse, "#7FFF00");
    this._colours.set(ColourEnum.Green, "#006400");
    this._colours.set(ColourEnum.BrightGreen, "#32CD32");
    this._colours.set(ColourEnum.Turquoise, "#00CED1");
    this._colours.set(ColourEnum.BrightTurquoise, "#00FFFF");
    this._colours.set(ColourEnum.Blue, "#0000CD");
    this._colours.set(ColourEnum.BrightBlue, "#00BFFF");
    this._colours.set(ColourEnum.Diamond, "#E0FFFF");
    this._colours.set(ColourEnum.Purple, "#800080");
    this._colours.set(ColourEnum.BrightPurple, "#EE82EE");
    this._colours.set(ColourEnum.Pink, "#FF1493");
    this._colours.set(ColourEnum.BrightPink, "#FF69B4");
  }

  private setupSounds() {
    this._sounds.set(SoundEffectsEnum.ActivateArtifact, [ "plm_aim_wand.wav"]);
    this._sounds.set(SoundEffectsEnum.Bell, [ "plm_jar_ding.wav"]);
    this._sounds.set(SoundEffectsEnum.BreathWeapon, [ "mco_attack_breath.wav"]);
    this._sounds.set(SoundEffectsEnum.BumpWall, [ "plm_wood_thud.wav"]);
    this._sounds.set(SoundEffectsEnum.CastSpell, [ "plm_spell1.wav", "plm_spell2.wav", "plm_spell3.wav"]);
    this._sounds.set(SoundEffectsEnum.Cursed, [ "pls_man_oooh.wav"]);
    this._sounds.set(SoundEffectsEnum.DestroyItem, [ "plm_bang_metal.wav", "plm_break_canister.wav", "plm_break_glass.wav", "plm_break_glass2.wav", "plm_break_plates.wav", "plm_break_shatter.wav", "plm_break_smash.wav", "plm_glass_breaking.wav", "plm_glass_break.wav", "plm_glass_smashing.wav"]);
    this._sounds.set(SoundEffectsEnum.Dig, [ "plm_metal_clank.wav"]);
    this._sounds.set(SoundEffectsEnum.DisarmTrap, [ "plm_bang_ceramic.wav", "plm_chest_latch.wav", "plm_click_switch3.wav"]);
    this._sounds.set(SoundEffectsEnum.Drop, [ "plm_drop_boot.wav"]);
    this._sounds.set(SoundEffectsEnum.Eat, [ "plm_eat_bite.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterDungeon1, [ "amb_door_iron.wav", "amb_bell_metal1.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterDungeon2, [ "amb_bell_tibet1.wav", "amb_bell_metal2.wav", "amb_gong_strike.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterDungeon3, [ "amb_bell_tibet2.wav", "amb_dungeon_echo.wav", "amb_pulse_low.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterDungeon4, [ "amb_bell_tibet3.wav", "amb_dungeon_echowet.wav", "amb_gong_undertone.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterDungeon5, [ "amb_door_doom.wav", "amb_gong_chinese.wav", "amb_gong_low.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterStore, [ "sto_bell_desk.wav", "sto_bell_ding.wav", "sto_bell_dingaling.wav", "sto_bell_jingles.wav", "sto_bell_ringing.wav", "sto_bell_shop.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterTownDay, [ "amb_thunder_rain.wav"]);
    this._sounds.set(SoundEffectsEnum.EnterTownNight, [ "amb_guitar_chord.wav", "amb_thunder_roll.wav"]);
    this._sounds.set(SoundEffectsEnum.FindSecretDoor, [ "id_bad_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.HealthWarning, [ "plc_bell_warn.wav"]);
    this._sounds.set(SoundEffectsEnum.HitGood, [ "plc_hit_anvil.wav"]);
    this._sounds.set(SoundEffectsEnum.HitGreat, [ "plc_hit_groan.wav"]);
    this._sounds.set(SoundEffectsEnum.HitHiGreat, [ "plc_hit_grunt.wav"]);
    this._sounds.set(SoundEffectsEnum.HitHiSuperb, [ "plc_hit_anvil2.wav"]);
    this._sounds.set(SoundEffectsEnum.HitSuperb, [ "plc_hit_grunt2.wav"]);
    this._sounds.set(SoundEffectsEnum.Hungry, [ "id_bad_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.IdentifyBad, [ "id_bad_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.IdentifyGood, [ "id_bad_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.IdentifySpecial, [ "id_bad_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.LeaveStore, [ "plm_door_bolt.wav"]);
    this._sounds.set(SoundEffectsEnum.LevelGain, [ "plm_levelup.wav"]);
    this._sounds.set(SoundEffectsEnum.LockpickFail, [ "plm_click_dry.wav", "plm_click_switch.wav", "plm_click_wood.wav", "plm_door_echolock.wav", "plm_door_wooden.wav"]);
    this._sounds.set(SoundEffectsEnum.LockpickSuccess, [ "plm_break_wood.wav", "plm_cabinet_open.wav", "plm_chest_unlatch.wav", "plm_lock_case.wav", "plm_lock_distant.wav", "plm_open_case.wav"]);
    this._sounds.set(SoundEffectsEnum.MeleeHit, [ "plc_hit_hay.wav", "plc_hit_body.wav"]);
    this._sounds.set(SoundEffectsEnum.Miss, [ "plc_miss_arrow2.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterBashes, [ "mco_squish_snap.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterBegs, [ "mco_man_mumble.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterBites, [ "mco_snarl_short.wav", "mco_bite_soft.wav", "mco_bite_munch.wav", "mco_bite_long.wav", "mco_bite_short.wav", "mco_bite_gnash.wav", "mco_bite_chomp.wav", "mco_bite_regular.wav", "mco_bite_small.wav", "mco_bite_dainty.wav", "mco_bite_hard.wav", "mco_bite_chew.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterBreeds, [ "mco_frog_trill.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterButts, [ "mco_cuica_rubbing.wav", "mco_thud_crash.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterCausesFear, [ "mco_creature_groan.wav", "mco_dino_slur.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterClaws, [ "mco_ceramic_trill.wav", "mco_scurry_dry.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterCrawls, [ "mco_card_shuffle.wav", "mco_shake_roll.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterCreatesTraps, [ "mco_thoing_deep.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterCrushes, [ "mco_dino_low.wav", "mco_squish_hit.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterDies, [ "mco_howl_croak.wav", "mco_howl_deep.wav", "mco_howl_distressed.wav", "mco_howl_high.wav", "mco_howl_long.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterDrools, [ "mco_creature_choking.wav", "mco_liquid_squirt.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterEngulfs, [ "mco_dino_talk.wav", "mco_dino_yawn.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterFlees, [ "mco_creature_yelp.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterGazes, [ "mco_thoing_backwards.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterHits, [ "mco_hit_whip.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterInsults, [ "mco_strange_thwoink.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterKicks, [ "mco_rubber_thud.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterMoans, [ "mco_strange_music.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterShrieks, [ "mco_mouse_squeaks.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterSpits, [ "mco_attack_spray.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterSpores, [ "mco_dub_wobble.wav", "mco_spray_long.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterStings, [ "mco_castanet_trill.wav", "mco_tube_hit.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterTouches, [ "mco_click_vibra.wav"]);
    this._sounds.set(SoundEffectsEnum.MonsterWails, [ "mco_dino_low.wav"]);
    this._sounds.set(SoundEffectsEnum.NothingToOpen, [ "plm_click_switch2.wav", "plm_door_knob.wav"]);
    this._sounds.set(SoundEffectsEnum.OpenDoor, [ "plm_door_bolt.wav", "plm_door_creak.wav", "plm_door_dungeon.wav", "plm_door_entrance.wav", "plm_door_open.wav", "plm_door_opening.wav", "plm_door_rusty.wav", "plm_door_squeaky.wav"]);
    this._sounds.set(SoundEffectsEnum.PickUpMoney1, [ "plm_coins_light.wav", "plm_coins_shake.wav"]);
    this._sounds.set(SoundEffectsEnum.PickUpMoney2, [ "plm_chain_light.wav", "plm_coins_pour.wav"]);
    this._sounds.set(SoundEffectsEnum.PickUpMoney3, [ "plm_coins_dump.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerAfraid, [ "pls_man_yell.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerBerserk, [ "pls_man_scream2.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerBlessed, [ "sum_angel_song.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerBlind, [ "pls_tone_conk.wav"]);
    this._sounds.set(SoundEffectsEnum.Playerconfused, [ "pls_man_ugh.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerCut, [ "pls_man_argoh.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerDeath, [ "plc_die_laugh.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerDrugged, [ "pls_breathe_in.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerHaste, [ "pls_bell_sustain.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerHeroism, [ "pls_tone_goblet.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerInfravision, [ "pls_tone_clavelo8.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerInvulnerable, [ "pls_tone_blurk.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerParalysed, [ "pls_man_gulp_new.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerPoisoned, [ "pls_tone_guiro.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerProtEvil, [ "pls_bell_glass.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerRecover, [ "pls_bell_chime_new.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerResistAcid, [ "pls_man_sniff.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerResistCold, [ "pls_tone_stick.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerResistElectric, [ "pls_tone_elec.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerResistFire, [ "pls_tone_scrape.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerResistPoison, [ "pls_man_spit.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerSeeInvisible, [ "pls_tone_clave6.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerShield, [ "pls_bell_bowl.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerSlow, [ "pls_man_sigh.wav"]);
    this._sounds.set(SoundEffectsEnum.PlayerStatDrain, [ "pls_tone_headstock.wav"]);
    this._sounds.set(SoundEffectsEnum.Pray, [ "sum_angel_song.wav"]);
    this._sounds.set(SoundEffectsEnum.PseudoId, [ "id_good_hmm.wav"]);
    this._sounds.set(SoundEffectsEnum.Quaff, [ "plm_bottle_clinks.wav", "plm_cork_pop.wav", "plm_cork_squeak.wav"]);
    this._sounds.set(SoundEffectsEnum.QuestMonsterDies, [ "amb_guitar_chord.wav"]);
    this._sounds.set(SoundEffectsEnum.RangedHit, [ "plc_hit_arrow.wav"]);
    this._sounds.set(SoundEffectsEnum.Shoot, [ "plc_miss_swish.wav", "plc_miss_arrow.wav"]);
    this._sounds.set(SoundEffectsEnum.ShutDoor, [ "plm_bang_dumpster.wav", "plm_cabinet_shut.wav", "plm_close_hatch.wav", "plm_door_creakshut.wav", "plm_door_latch.wav", "plm_door_shut.wav", "plm_door_slam.wav"]);
    this._sounds.set(SoundEffectsEnum.StairsDown, [ "plm_floor_creak.wav"]);
    this._sounds.set(SoundEffectsEnum.StairsUp, [ "plm_floor_creak2.wav"]);
    this._sounds.set(SoundEffectsEnum.StoreSoldBargain, [ "id_bad_dang.wav"]);
    this._sounds.set(SoundEffectsEnum.StoreSoldCheaply, [ "sto_man_haha.wav"]);
    this._sounds.set(SoundEffectsEnum.StoreSoldExtraCheaply, [ "sto_man_whoohaha.wav"]);
    this._sounds.set(SoundEffectsEnum.StoreSoldWorthless, [ "sto_man_hey.wav"]);
    this._sounds.set(SoundEffectsEnum.StoreTransaction, [ "sto_coins_countertop.wav", "sto_bell_register1.wav", "sto_bell_register2.wav"]);
    this._sounds.set(SoundEffectsEnum.Study, [ "plm_book_pageturn.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonAngel, [ "sum_angel_song.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonAnimals, [ "sum_lion_growl.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonDemons, [ "sum_ghost_wail.wav", "sum_laugh_evil2.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonDragons, [ "sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonGreaterDemons, [ "sum_ghost_moan.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonGreaterDragons, [ "sum_gong_temple.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonGreaterUndead, [ "sum_ghost_moan.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonHounds, [ "sum_lion_growl.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonHydras, [ "sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonMonster, [ "sum_chime_jangle.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonRingwraiths, [ "sum_bell_hand.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonSpiders, [ "sum_piano_scrape.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonUndead, [ "sum_ghost_oooo.wav"]);
    this._sounds.set(SoundEffectsEnum.SummonUniques, [ "sum_bell_tone.wav"]);
    this._sounds.set(SoundEffectsEnum.Teleport, [ "plm_chimes_jangle.wav"]);
    this._sounds.set(SoundEffectsEnum.TeleportLevel, [ "sum_bell_crystal.wav"]);
    this._sounds.set(SoundEffectsEnum.UniqueDies, [ "sum_ghost_wail.wav"]);
    this._sounds.set(SoundEffectsEnum.UseStaff, [ "plm_use_staff.wav"]);
    this._sounds.set(SoundEffectsEnum.WieldWeapon, [ "plm_metal_sharpen.wav"]);
    this._sounds.set(SoundEffectsEnum.ZapRod, [ "plm_zap_rod.wav"]);
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

  private check() {
    if (this.connection !== undefined && this.gameGuid !== undefined) {
      this.connection.start().then(() => {
        if (this.connection) {
          this.connectionId = this.connection.connectionId;

          this.connection.on("SetCellBackground", (row: number, col: number, c: string, color: ColourEnum) => {
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
          this.connection.on("UnsetCellBackground", (row: number, col: number, c: string, color: ColourEnum) => {
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
          this.connection.on("Print", (row: number, col: number, text: string, color: ColourEnum) => {
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

              // Get the list of available sounds.
              const availableSounds: string[] | undefined = this._sounds.get(sound);

              // Ensure there are sounds available.
              if (availableSounds !== undefined) {
                const randomSelection = Math.floor(Math.random() * availableSounds.length);

                // Choose one.
                var soundResourceName = availableSounds[randomSelection];

                // Play it.
                const audio = new Audio();
                audio.src = `/assets/sounds/${soundResourceName}`;
                audio.load();
                audio.play();
              }
            });
          });
          this.connection.on("PlayMusic", (music: number) => {
            this._zone.run(() => {
            });
          });
          this.connection.on("GameOver", () => {
            this._router.navigate(['/']);
          });

          this.connection.send("play", this.gameGuid);
        }
      }, () => {
        this._snackBar.open("Connection to game server failed.", undefined, {
          duration: 2000,
        });
        this._router.navigate(['/']);
      });
    }
  }

  ngOnInit() {
    this.setupSounds();
    this.setupColorMap();

    // Wait for the authentication.  Games can only be played with authenticated.
    this._initSubscriptions.add(this._authenticationService.currentUser.subscribe((_currentUser: UserDetails | null) => {
      if (_currentUser !== null) {
        // Get the access token for this user.  We need it for the signal-r hub authorization.
        const accessToken = _currentUser.jwt;

        // Ensure there is an access token and that the connection has been established already.
        if (accessToken !== null && accessToken !== undefined && this.connection == undefined) {
          // Create the signal-r connection object.
          this.connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/game-hub", {
            accessTokenFactory: () => accessToken,
          }).build();
          this.check();
        }
      }
    }));

    // Retrieve the game guid from the query.
    this._initSubscriptions.add(this._activatedRoute.paramMap.subscribe((paramMap) => {
      this.gameGuid = paramMap.get("guid");
      this.check();
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
