import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, HostListener, NgZone, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import * as SignalR from "@microsoft/signalr";
import { Observable } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { SavedGameDetails } from './saved-game-details';

export class PostNewGame {
  public username: string = "";
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [
    './home.component.scss'
  ]
})
export class HomeComponent implements OnInit {
  @ViewChild('console', { static: true }) private canvasRef: ElementRef | undefined;
  public readonly connection = new SignalR.HubConnectionBuilder().withUrl("/apiv1/hub").build();
  public savedGames: SavedGameDetails[] | undefined = undefined;
  public displayedColumns: string[] = ["character-name", "gold", "level", "is-alive", "last-saved", "notes"];
  public selectedSavedGame: SavedGameDetails | null = null;
  public isAuthenticated?: Observable<boolean>;

  constructor(
    private _httpClient: HttpClient,
    private authorizeService: AuthorizeService,
    private _router: Router
  ) {
  }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this._httpClient.get<SavedGameDetails[]>(`/apiv1/games`).toPromise().then((_savedGames) => {
      this.savedGames = _savedGames;
    }, (error: HttpErrorResponse) => {

    });
  }

  public onRowClick(savedGame: SavedGameDetails) {
    this._router.navigate(['/play', savedGame.guid]);
  }

  public onNewGame() {
    this._router.navigate(['/play']);
  }
}
