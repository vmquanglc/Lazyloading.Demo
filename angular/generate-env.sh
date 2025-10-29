#!/bin/sh
# Script to generate ABP appsettings.json from environment variables

cat > /usr/share/nginx/html/assets/appsettings.json << EOF
{
  "production": ${PRODUCTION},
  "application": {
    "name": "${APP_NAME}",
    "baseUrl": "${APP_BASE_URL}"
  },
  "oAuthConfig": {
    "issuer": "${OAUTH_ISSUER}",
    "redirectUri": "${APP_BASE_URL}",
    "clientId": "${OAUTH_CLIENT_ID}",
    "responseType": "${OAUTH_RESPONSE_TYPE}",
    "scope": "${OAUTH_SCOPE}",
    "requireHttps": ${OAUTH_REQUIRE_HTTPS}
  },
  "apis": {
    "default": {
      "url": "${API_DEFAULT_URL}",
      "rootNamespace": "${API_DEFAULT_ROOT_NAMESPACE}"
    },
    "AbpAccountPublic": {
      "url": "${OAUTH_ISSUER}",
      "rootNamespace": "QUANGSTAR"
    }
  }
}
EOF

cat /usr/share/nginx/html/assets/appsettings.json
