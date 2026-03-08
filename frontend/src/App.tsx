const highlights = [
  "Upload bank and credit card statements",
  "Resolve duplicates and settlements",
  "Classify expenses vs investments",
  "Explain every categorization decision"
];

export default function App() {
  return (
    <main>
      <header>
        <h1>Expense Tracker Intelligence</h1>
        <p>
          Understand how your money moves with transparent analysis and user-first
          controls.
        </p>
      </header>
      <section>
        <h2>Phase 1 focus</h2>
        <ul>
          {highlights.map((item) => (
            <li key={item}>{item}</li>
          ))}
        </ul>
      </section>
    </main>
  );
}
