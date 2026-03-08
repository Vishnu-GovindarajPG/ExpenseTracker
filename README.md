# ExpenseTracker

Starter monorepo for the ExpenseTracker MVP:

- **Frontend**: React + TypeScript (Vite)
- **API Gateway**: ASP.NET Core (.NET 8)
- **Analytics & AI**: FastAPI (Python)

## Repository layout

```
frontend/                 # React + TypeScript UI
services/api-gateway/     # ASP.NET Core API gateway
services/analytics/       # FastAPI analytics + classification
.github/workflows/ci.yml  # CI pipeline for lint/test/build
```

## Local development

### Frontend

```bash
cd frontend
npm install
npm run dev
```

### API Gateway

```bash
cd services/api-gateway

dotnet run --project src/ExpenseTracker.ApiGateway.csproj
```

### Analytics Service

```bash
cd services/analytics

python -m venv .venv
source .venv/bin/activate
pip install -r requirements.txt -r requirements-dev.txt
uvicorn app.main:app --reload
```

## Fly.io deployment

Each app has its own `Dockerfile` and `fly.toml`:

- `frontend/`
- `services/api-gateway/`
- `services/analytics/`

Deploy one-by-one:

```bash
cd services/analytics && fly deploy
cd ../api-gateway && fly deploy
cd ../../frontend && fly deploy
```

### Required secrets

Frontend app (`expense-tracker-frontend`):

- `VITE_API_GATEWAY_BASE_URL`
- `VITE_ANALYTICS_BASE_URL`

API gateway app (`expense-tracker-api-gateway`):

- `ASPNETCORE_ENVIRONMENT=Production`
- `ASPNETCORE_URLS=http://0.0.0.0:8080`
- `FRONTEND_ORIGIN=<frontend-domain>`
- `SUPABASE_URL`
- `SUPABASE_SERVICE_ROLE_KEY`
- `ANALYTICS_BASE_URL`

Analytics app (`expense-tracker-analytics`):

- `PORT=8080`
- `ENVIRONMENT=production`
- `SUPABASE_URL`
- `SUPABASE_SERVICE_ROLE_KEY`

## Quality gates

The CI pipeline runs on every push/pull request to `main` and fails the build if:

- Frontend linting, tests, or build fail.
- API gateway build/tests fail (warnings are treated as errors).
- Analytics linting or tests fail.
