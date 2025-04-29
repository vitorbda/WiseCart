// /app/shopping/_layout.js
import { Stack } from "expo-router";
import React from "react";

export default function ShoppingLayout() {
  return (
    <Stack>
      {/* A tela principal (index.js) será a primeira da stack */}
      <Stack.Screen name="index" options={{ headerShown: false }} />
      {/* A tela secundária */}
      <Stack.Screen name="shopping/[id]" options={{ headerShown: false }} />
    </Stack>
  );
}
