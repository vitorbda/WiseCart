/** @type {import('tailwindcss').Config} */
module.exports = {
    // NOTE: Update this to include the paths to all of your component files.
    content: [
      // Cobrirá src/app/(public), src/app/(tabs), etc.
      "./src/app/**/*.{js,jsx,ts,tsx}",
      // Se tiver arquivos em src/navigation também
      "./src/navigation/**/*.{js,jsx,ts,tsx}",
      // Se usar App.js/ts na raiz
      "./App.{js,jsx,ts,tsx}"
    ],
    presets: [require("nativewind/preset")],
    theme: {
      extend: {},
    },
    plugins: [],
  }