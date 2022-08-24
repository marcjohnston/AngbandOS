const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:7091';

const PROXY_CONFIG = [
  {
    context: [
      "/_configuration",
      "/.well-known",
      "/Identity",
      "/connect",
      "/ApplyDatabaseMigrations",
      "/_framework",
      "/apiv1/game-hub",
      "/apiv1/service-hub",
      "/apiv1/saved-games",
      "/apiv1/games",
      "/apiv1/accounts"
   ],
    target: target,
    secure: false,
    ws: true,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
