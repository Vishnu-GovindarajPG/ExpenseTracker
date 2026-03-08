import { render, screen } from "@testing-library/react";
import App from "./App";

describe("App", () => {
  it("renders the headline and highlights", () => {
    render(<App />);

    expect(
      screen.getByRole("heading", { name: /Expense Tracker Intelligence/i })
    ).toBeInTheDocument();

    expect(
      screen.getByText(/Resolve duplicates and settlements/i)
    ).toBeInTheDocument();
  });
});
