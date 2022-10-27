import { ActiveUserDetails } from "./active-user-details";

export class HubConnections {
    public chatHubConnections: ActiveUserDetails[] | undefined;
    public gameHubConnections: ActiveUserDetails[] | undefined;
    public adminHubConnections: ActiveUserDetails[] | undefined;
    public serviceHubConnections: ActiveUserDetails[] | undefined;
    public spectatorsHubConnections: ActiveUserDetails[] | undefined;
}
