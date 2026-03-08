from datetime import datetime, timezone
from typing import Literal

from fastapi import FastAPI
from pydantic import BaseModel, Field

app = FastAPI(title="ExpenseTracker Analytics")


class HealthResponse(BaseModel):
    service: str = Field(..., examples=["ExpenseTracker Analytics"])
    status: Literal["Healthy"]
    timestamp: datetime


class ClassificationRequest(BaseModel):
    description: str
    amount: float


class ClassificationResponse(BaseModel):
    description: str
    category: Literal["expense", "investment", "unknown"]
    confidence: float
    explanation: str


@app.get("/health", response_model=HealthResponse)
async def health() -> HealthResponse:
    return HealthResponse(
        service="ExpenseTracker Analytics",
        status="Healthy",
        timestamp=datetime.now(timezone.utc),
    )


@app.post("/classify", response_model=ClassificationResponse)
async def classify(request: ClassificationRequest) -> ClassificationResponse:
    lowered = request.description.lower()
    if any(keyword in lowered for keyword in {"mutual fund", "stock", "gold"}):
        category = "investment"
        explanation = "Matched investment keyword"
        confidence = 0.82
    elif any(keyword in lowered for keyword in {"grocery", "fuel", "travel"}):
        category = "expense"
        explanation = "Matched expense keyword"
        confidence = 0.8
    else:
        category = "unknown"
        explanation = "Insufficient data; requires user confirmation"
        confidence = 0.4

    return ClassificationResponse(
        description=request.description,
        category=category,
        confidence=confidence,
        explanation=explanation,
    )
