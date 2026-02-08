module.exports = {
  root: true,
  env: { browser: true, es2020: true },
  extends: [
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended",
    "plugin:react/recommended",
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
  plugins: ["@typescript-eslint", "react", "react-refresh", "vitest"],
  rules: {
    "react/react-in-jsx-scope": "off",
    "react-refresh/only-export-components": ["warn", { allowConstantExport: true }]
  },
  settings: {
    react: {
      version: "detect"
    }
  },
  overrides: [
    {
      files: ["**/*.test.ts", "**/*.test.tsx"],
      extends: ["plugin:vitest/recommended"]
    }
  ]
};
