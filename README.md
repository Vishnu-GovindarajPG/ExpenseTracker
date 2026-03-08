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

## Quality gates

The CI pipeline runs on every push/pull request to `main` and fails the build if:

- Frontend linting, tests, or build fail.
- API gateway build/tests fail (warnings are treated as errors).
- Analytics linting or tests fail.
