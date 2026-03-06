import { Injectable, OnDestroy } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { BehaviorSubject, Subject, Subscription } from 'rxjs';
import { ChatMessage } from '../chat/chat-message';
import { ActiveGameDetails } from '../home/active-game-details';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class HubService implements OnDestroy {
  private _chatConnection: HubConnection | undefined;
  private _serviceConnection: HubConnection | undefined;

  // Emitters for consumers to subscribe to
  public onChatRefreshed = new Subject<ChatMessage[]>();
  public onChatUpdated = new Subject<ChatMessage>();
  public onMessageFailed = new Subject<void>();
  public onActiveGamesUpdated = new Subject<ActiveGameDetails[]>();

  // Expose connection id changes
  public connectionId$ = new BehaviorSubject<string | null>(null);

  // Authentication / status observables
  public isAuthenticated$ = new BehaviorSubject<boolean>(false);
  public isAdministrator$ = new BehaviorSubject<boolean>(false);
  public status$ = new Subject<string>();

  private _authSubscription: Subscription;

  constructor(private _authenticationService: AuthenticationService) {
    // Subscribe to authentication changes and react by switching hubs.
    this._authSubscription = this._authenticationService.currentUser.subscribe(() => {
      this.handleAuthenticationChange();
    }, (err: any) => {
      // Surface auth subscription errors to consumers
      this.status$.next(`Error subscribing to authentication service ${err}`);
    });

    // Handle initial state immediately.
    this.handleAuthenticationChange();
  }

  private handleAuthenticationChange(): void {
    this.status$.next('Reconnecting to chat.');
    this.disconnectHubs().then(() => {
      const current = this._authenticationService.currentUser.value;
      if (current == null || current?.jwt === undefined) {
        // Connect to anonymous service hub
        this.isAuthenticated$.next(false);
        this.isAdministrator$.next(false);
        this.status$.next('Connecting to service hub.');
        this.connectServiceHub().catch((reason: any) => {
          this.status$.next(`Cannot connect to service '${reason}'`);
        });
      } else {
        // Connect to authenticated chat hub
        this.isAuthenticated$.next(true);
        this.isAdministrator$.next(current.isAdmin ?? false);
        this.status$.next('Connecting to chat hub.');
        this.connectChatHub(current.jwt).catch((reason: any) => {
          this.status$.next(`Cannot connect to chat '${reason}'`);
        });
      }
    });
  }

  public connectServiceHub(): Promise<void> {
    // If already initialized, return resolved promise to avoid duplicate initialization.
    if (this._serviceConnection !== undefined) {
      return Promise.resolve();
    }

    // Initialize only as needed
    this._serviceConnection = new HubConnectionBuilder().withUrl('/apiv1/service-hub').build();

    // Register handlers before start.
    this._serviceConnection.on('ChatRefreshed', (history: ChatMessage[]) => {
      this.onChatRefreshed.next(history);
    });
    this._serviceConnection.on('ChatUpdated', (message: ChatMessage) => {
      this.onChatUpdated.next(message);
    });
    this._serviceConnection.on('ActiveGamesUpdated', (activeGames: ActiveGameDetails[]) => {
      this.onActiveGamesUpdated.next(activeGames);
    });

    return this._serviceConnection.start().then(() => {
      this.connectionId$.next(`Service: ${this._serviceConnection?.connectionId ?? null}`);
      // Request initial refresh (best-effort)
      if (this._serviceConnection) {
        this._serviceConnection.send('RefreshChat', null).catch(() => { /* ignore send errors here */ });
        this._serviceConnection.send('RefreshActiveGames').catch(() => { /* ignore send errors here */ });
      }
    });
  }

  public connectChatHub(accessToken: string): Promise<void> {
    // If already initialized, return resolved promise to avoid duplicate initialization.
    if (this._chatConnection !== undefined) {
      return Promise.resolve();
    }

    // Initialize only as needed
    this._chatConnection = new HubConnectionBuilder().withUrl('/apiv1/chat-hub', {
      accessTokenFactory: () => accessToken
    }).build();

    // Register handlers before start.
    this._chatConnection.on('ChatRefreshed', (history: ChatMessage[]) => {
      this.onChatRefreshed.next(history);
    });
    this._chatConnection.on('ChatUpdated', (message: ChatMessage) => {
      this.onChatUpdated.next(message);
    });
    this._chatConnection.on('MessageFailed', () => {
      this.onMessageFailed.next();
    });

    return this._chatConnection.start().then(() => {
      this.connectionId$.next(`Chat: ${this._chatConnection?.connectionId ?? null}`);
      if (this._chatConnection) {
        this._chatConnection.send('RefreshChat', null).catch(() => { /* ignore send errors here */ });
      }
    });
  }

  private disconnectHubs(): Promise<void> {
    const stops: Promise<void>[] = [];

    if (this._serviceConnection) {
      this._serviceConnection.off('ChatUpdated');
      this._serviceConnection.off('ChatRefreshed');
      this._serviceConnection.off('ActiveGamesUpdated');
      stops.push(this._serviceConnection.stop());
    }

    if (this._chatConnection) {
      this._chatConnection.off('ChatUpdated');
      this._chatConnection.off('MessageFailed');
      this._chatConnection.off('ChatRefreshed');
      stops.push(this._chatConnection.stop());
    }

    return Promise.all(stops).then(() => {
      this._serviceConnection = undefined;
      this._chatConnection = undefined;
      this.connectionId$.next(null);
    });
  }

  public sendMessage(text: string): Promise<void> {
    if (!this._chatConnection) {
      return Promise.reject(new Error('No chat connection available'));
    }
    return this._chatConnection.send('SendMessage', null, text);
  }

  public deleteMessage(id: number): Promise<void> {
    if (!this._chatConnection) {
      return Promise.reject(new Error('No chat connection available'));
    }
    return this._chatConnection.send('DeleteMessage', id);
  }

  ngOnDestroy(): void {
    this._authSubscription.unsubscribe();
    // Best-effort disconnect; ignore promise result.
    this.disconnectHubs();
  }
}
