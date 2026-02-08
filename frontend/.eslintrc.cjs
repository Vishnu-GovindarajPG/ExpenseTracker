module.exports = {
  root: true,
  env: { browser: true, es2020: true },
  extends: [
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:react-hooks/recommended"
  ],
  ignorePatterns: ["dist", ".eslintrc.cjs"],
  parserOptions: {
    ecmaVersion: "latest",
    sourceType: "module",
    project: "./tsconfig.json",
    tsconfigRootDir: __dirname
  },
  parser: "@typescript-eslint/parser",
  plugins: ["@typescript-eslint", "react-refresh", "vitest"],
  rules: {
    "react-refresh/only-export-components": ["warn", { allowConstantExport: true }]
  },
  overrides: [
    {
      files: ["**/*.test.ts", "**/*.test.tsx"],
      env: { "vitest/globals": true }
    }
  ]
};
