from fastapi.testclient import TestClient

from app.main import app


def test_classify_investment_keyword():
    client = TestClient(app)
    response = client.post(
        "/classify",
        json={"description": "Monthly mutual fund SIP", "amount": 1200.0},
    )

    assert response.status_code == 200
    payload = response.json()
    assert payload["category"] == "investment"
    assert payload["confidence"] >= 0.8
