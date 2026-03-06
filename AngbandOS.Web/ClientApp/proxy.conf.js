const { env } = require('process'); // import process.env as `env` so environment variables can be read
const http = require('http'); // load Node's `http` module (used below to create an Agent for HTTP)
const https = require('https'); // load Node's `https` module (used below to create an Agent for HTTPS)

// If ASPNETCORE_HTTPS_PORT set, target HTTPS localhost with that port else if ASPNETCORE_URLS set, use its first URL; otherwise fallback to this default
const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7091';

// Create agents with no artificial socket limit so many concurrent websocket connections are allowed.
const httpAgent = new http.Agent({ keepAlive: true, maxSockets: Infinity });
const httpsAgent = new https.Agent({ keepAlive: true, maxSockets: Infinity });

const PROXY_CONFIG = [
  {
    context: [
      "/_configuration", // often used by the SPA to fetch server-side runtime configuration (feature flags, API base URLs, client settings). If you remove it the app may not get required configuration at startup.
      "/.well-known", // OpenID Connect / OAuth2 discovery endpoints live here (e.g., /.well-known/openid-configuration). The SPA or auth library uses this to discover issuer, endpoints and keys. Without it automatic auth flows and token validation will break.
      "/Identity", //  ASP.NET Core Identity UI endpoints (account management, login pages, static resources under Identity). If you use the built-in Identity UI (or redirect flows that hit those URLs) requests must be proxied so the browser reaches the server
      "/connect", // common prefix for OAuth/OIDC endpoints (IdentityServer or middleware) like /connect/authorize, /connect/token, /connect/endsession. These are required for authorization flows (and sometimes the token exchange used by SignalR when you pass access tokens)
      "/_framework", // static assets emitted by ASP.NET (Blazor / framework scripts, runtime files). If your app loads any server-side static framework assets through the same origin, they must be proxied or the browser will fail to load them

      // Proxy API endpoints used by the game.
      "/apiv1/saved-games",
      "/apiv1/games",
      "/apiv1/configurations",
      "/apiv1/accounts",
      "/apiv1/admin-hub",
      "/apiv1/game-hub",
      "/apiv1/spectators-hub",
      "/apiv1/game-messages-hub",
      "/apiv1/service-hub",
      "/apiv1/chat-hub"
    ],
    target: target, // forward matching requests to the `target` URL computed above
    secure: false, // disable strict SSL verification for the target (useful for local self-signed certs)
    ws: true, // enable proxying of WebSocket upgrade requests (required for SignalR over WebSockets)
    
    agent: target.startsWith('https') ? httpsAgent : httpAgent, // // pick correct agent depending on scheme choose HTTPS or HTTP Agent based on `target` scheme
    changeOrigin: true // rewrite the Host header to the target's host (useful when backend expects its own host)
  }
]

module.exports = PROXY_CONFIG; // export the configuration array so Angular CLI / dev server can consume it
