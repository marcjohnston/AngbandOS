import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subscription } from 'rxjs';
import { AuthenticationService } from '../accounts/authentication-service/authentication.service';
import { UserDetails } from '../accounts/authentication-service/user-details';
import { ChatMessage } from './chat-message';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { ChangeDetectorRef } from '@angular/core';
import { MatButton, MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    NgFor,
    NgIf,
    MatIconModule,
    MatCardModule,
    MatButtonModule
  ]
})
export class ChatComponent implements OnInit, OnDestroy {
  public history: ChatMessage[] | undefined;
  public isAuthenticated: boolean = false;
  public isAdministrator = false;
  public connectionId: string | null = null;
  public hasMoreMessages: boolean = false;

  /** Returns true, while a request for older messages is outstanding.  Prevents duplicate requests from repeated clicks. */
  public isLoadingMoreMessages: boolean = false;

  /** Returns the oldest message ID sent with the outstanding RefreshChat request, or null when the request is for the most recent page.  Determines whether the reply replaces or prepends the history. */
  private _requestedOldestDownloadedMessageId: number | null = null;

  @ViewChild('scrollDiv', { static: true }) private scrollDivRef: ElementRef | undefined;
  private _initSubscriptions = new Subscription();
  private _chatConnection: HubConnection | undefined; // Initialized only as needed due to two different authentication channels.
  private _serviceConnection: HubConnection | undefined; // Initialized only as needed due to two different authentication channels.

  constructor(
    private _authenticationService: AuthenticationService,
    private _snackBar: MatSnackBar,
    private _changeDetectorRef: ChangeDetectorRef
  ) {
  }

  public formatDate(dateString: string | undefined) {
    if (dateString === undefined) {
      return "-";
    }

    const dateNumber: number = Date.parse(dateString);
    const date: Date = new Date(dateNumber);
    const now: Date = new Date();

    // Check to see if the message was sent today.
    if (date.getDate() === now.getDate() && date.getMonth() === now.getMonth() && date.getFullYear() === now.getFullYear()) {
      // Do not show the date.
      return date.toLocaleTimeString([], { hour: 'numeric', minute: 'numeric' });
    } else {
      // Show the date and the time.
      return date.toLocaleDateString();
      ;
    }
  }

  public deleteMessage(message: ChatMessage) {
    if (this._chatConnection !== undefined) {
      this._chatConnection.send("DeleteMessage", message.id);
    }
  }

  public input(event: Event) {
    if (this._chatConnection !== undefined) {
      const inputElement: HTMLTextAreaElement = event.currentTarget as HTMLTextAreaElement;
      const text: string = inputElement.value;
      if (text.endsWith("\n")) {
        const strippedText = text.slice(0, -1);
        if (strippedText.length > 0) {
          this._chatConnection.send("SendMessage", null, strippedText);
        }
        inputElement.value = "";
      }
    }
  }

  private scrollToBottomOfChat() {
    const scrollDiv: HTMLDivElement = this.scrollDivRef?.nativeElement as HTMLDivElement;
    scrollDiv.scrollTop = scrollDiv.scrollHeight;
  }

  /** Returns the connection that is currently active; the chat hub for authenticated users or the service hub for anonymous users. */
  private get activeConnection(): HubConnection | undefined {
    return this._chatConnection ?? this._serviceConnection;
  }

  /** Returns the ID of the oldest message in the history; or null, if there is no history.  All messages with this ID and higher have been downloaded. */
  private get oldestDownloadedMessageId(): number | null {
    if (this.history === undefined || this.history.length === 0) {
      return null;
    }
    return Math.min(...this.history.map(_message => _message.id!));
  }

  /** Requests a page of chat messages from the server.  Null requests the most recent page; otherwise, the page of messages older than the ID. */
  private refreshChat(connection: HubConnection, oldestDownloadedMessageId: number | null) {
    this._requestedOldestDownloadedMessageId = oldestDownloadedMessageId;
    connection.send("RefreshChat", oldestDownloadedMessageId);
  }

  /** Requests the next page of older messages.  Invoked by the "Get More Messages" button. */
  public getMoreMessages() {
    const connection = this.activeConnection;
    const oldestDownloadedMessageId = this.oldestDownloadedMessageId;
    if (connection === undefined || oldestDownloadedMessageId === null || !this.hasMoreMessages || this.isLoadingMoreMessages) {
      return;
    }
    this.isLoadingMoreMessages = true;
    this.refreshChat(connection, oldestDownloadedMessageId);
  }

  /** Handles a page of chat messages from the server.  The initial page replaces the history; pages of older messages are inserted at the top. */
  private chatRefreshed(history: ChatMessage[], hasMoreMessages: boolean | undefined) {
    this.hasMoreMessages = hasMoreMessages === true;
    this.isLoadingMoreMessages = false;
    if (this._requestedOldestDownloadedMessageId === null || this.history === undefined) {
      this.updateHistory(history);
    } else {
      this.prependHistory(history);
    }
  }

  /** Inserts older messages at the top of the history and keeps the messages the user was looking at in the same place on the screen. */
  private prependHistory(olderMessages: ChatMessage[]) {
    const scrollDiv: HTMLDivElement = this.scrollDivRef?.nativeElement as HTMLDivElement;
    const previousScrollHeight = scrollDiv.scrollHeight;
    const previousScrollTop = scrollDiv.scrollTop;

    this.history = olderMessages.concat(this.history ?? []);
    this._changeDetectorRef.detectChanges();

    // The new messages pushed the existing ones down; scroll by the same amount so the view does not jump.
    scrollDiv.scrollTop = previousScrollTop + (scrollDiv.scrollHeight - previousScrollHeight);
  }


  private updateHistory(history: ChatMessage[]) {
    this.history = history;
    this._changeDetectorRef.detectChanges();
    this.scrollToBottomOfChat();
  }

  private appendHistory(message: ChatMessage) {
    this.history?.push(message);
    this._changeDetectorRef.detectChanges();
    this.scrollToBottomOfChat();
  }

  private connectServiceHub() {
    // Since we bounce back and forth between the chat and service hubs depending on the authentication of the user, we will initialize the
    // connection only as needed.
    this.showMessage("Connecting to service hub.");
    this._serviceConnection = new HubConnectionBuilder().withUrl("/apiv1/service-hub").build();

    // Register handlers before start.
    this._serviceConnection.on("ChatRefreshed", (_history: ChatMessage[], _hasMoreMessages: boolean | undefined) => {
      this.chatRefreshed(_history, _hasMoreMessages);
    });
    this._serviceConnection.on("ChatUpdated", (_message: ChatMessage) => {
      this.appendHistory(_message);
    });

    this._serviceConnection.start().then(() => {
      this.connectionId = `Service: ${this._serviceConnection?.connectionId!}`;
      if (this._serviceConnection !== undefined) {
        this.refreshChat(this._serviceConnection, null);
      }
    }, (reason: any) => {
      this.showMessage(`Cannot connect to service '${reason}'`);
    });
  }

  private connectChatHub(accessToken: string) {
    // Since we bounce back and forth between the chat and service hubs depending on the authentication of the user, we will initialize the
    // connection only as needed.
    this._chatConnection = new HubConnectionBuilder().withUrl("/apiv1/chat-hub", {
      accessTokenFactory: () => accessToken
    }).build();

    // Register handlers before start.
    this._chatConnection.on("ChatRefreshed", (_history: ChatMessage[], _hasMoreMessages: boolean | undefined) => {
      this.chatRefreshed(_history, _hasMoreMessages);
    });
    this._chatConnection.on("ChatUpdated", (_message: ChatMessage) => {
      this.appendHistory(_message);
    });
    this._chatConnection.on("MessageFailed", () => {
      this.showMessage("Unable to send message.");
      this._changeDetectorRef.detectChanges();
    });

    this._chatConnection.start().then(() => {
      this.connectionId = `Chat: ${this._chatConnection?.connectionId!}`;
      if (this._chatConnection !== undefined) {
        this.refreshChat(this._chatConnection, null);
      }
    }, (reason: any) => {
      this.showMessage(`Cannot connect to chat '${reason}'`);
    });
  }

  private showMessage(message: string) {
    this._snackBar.open(message, "", {
      duration: 5000
    });
    this._changeDetectorRef.detectChanges();
  }

  private handleAuthenticationChange() {
    this.disconnectHubs().then(() => {

      // Check to see if we are authenticated.
      if (this._authenticationService.currentUser.value == null || this._authenticationService.currentUser.value?.jwt === undefined) {
        // Connect to the anonymous service-hub.
        this.isAuthenticated = false;
        this.connectServiceHub();
      } else {
        this.isAuthenticated = true;
        this.isAdministrator = this._authenticationService.currentUser.value?.isAdmin!;
        const accessToken = this._authenticationService.currentUser.value.jwt;
        this.connectChatHub(accessToken);
      }
    });
  }

  ngOnInit(): void {
    // Subscribe to the current user so that we can check the authentication.
    const currentUserSubscription = this._authenticationService.currentUser.subscribe((_user: UserDetails | null) => {
      this.handleAuthenticationChange();
    }, (error: any) => {
      this.showMessage(`"Error subscribing to authentication service {error}`);
    });
    this._initSubscriptions.add(currentUserSubscription);
  }

  /**
   * Disconnect from both the chat and service hubs.  Resolves only after all 
   */
  private disconnectHubs(): Promise<void> {
    const chatAndServiceHubs: Promise<void>[] = [];
    if (this._serviceConnection !== undefined) {
      this.showMessage(`Disconnecting from service hub.`);

      this._serviceConnection.off("ChatUpdated");
      this._serviceConnection.off("ChatRefreshed");

      chatAndServiceHubs.push(this._serviceConnection.stop());
    }
    if (this._chatConnection !== undefined) {
      this._chatConnection.off("ChatUpdated");
      this._chatConnection.off("MessageFailed");
      this._chatConnection.off("ChatRefreshed");

      chatAndServiceHubs.push(this._chatConnection.stop());
    }

    return Promise.all(chatAndServiceHubs).then(() => {
      this._serviceConnection = undefined;
      this._chatConnection = undefined;

      this.hasMoreMessages = false;
      this.isLoadingMoreMessages = false;
      this._requestedOldestDownloadedMessageId = null;
    });
  }

  ngOnDestroy() {
    this._initSubscriptions.unsubscribe();
    this.disconnectHubs();
  }
}
