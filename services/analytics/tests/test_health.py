from fastapi.testclient import TestClient

from app.main import app


def test_health_returns_status():
    client = TestClient(app)
    response = client.get("/health")

    assert response.status_code == 200
    payload = response.json()
    assert payload["service"] == "ExpenseTracker Analytics"
    assert payload["status"] == "Healthy"
