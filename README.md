# Fagkveld Multitenant

Vi lager en app registration og kobler opp et enkelt api til dette.

# Last ned koden og lag App Registration

Pass på å lage denne som "any organizational directory".

## "Authentication"

Legg til redirect URL. (Add a platform => SPA)

- https://localhost:5001/oauth2-redirect.html

Slå på Access tokens og ID tokens.

## Eksponer api'et.

Expose an API => Add a scope
La Application ID URI være som den blir foreslått.
Kall scope for api-access og la det være tilgjengelig for både admin og brukere.
Legg til beskrivelser.

## Roller

Under "App roles" legger du til noen roller.
For eksempelet i koden brukes rollen "Admin". Pass på at "Value" har denne verdien.

## Oppsett i appsettings.json

Legg inn verdier under områdende AzureAd og Swagger.

## Oppsett av pålogging fra Swagger

Sett opp OAuth med implicit flow for å få Swagger til å logge på mot API'et.
Pass på å få med Scopes, AuthorizationUrl og TokenUrl.

Hint: https://learn.microsoft.com/en-us/entra/identity-platform/msal-client-application-configuration

## Kjør prosjektet

Test at du får logget på og kjørt API kall.
Får du gitt deg tilgang til å ha rollen Admin og kjørt API kallet som krever denne tilgangen? (Hint Enterprise applications)
Har du en annen organisasjonskonto, så kan du jo teste med den.
