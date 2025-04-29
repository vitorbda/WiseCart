// app/_layout.tsx
import { Stack } from 'expo-router';
import { AuthProvider } from '../contexts/AuthContext';
import "nativewind/types.d";
import React from 'react';

export default function RootLayout() {
  return (
    <AuthProvider>
      {/* 
        O Stack abaixo é gerado pelo Expo Router. 
        Ele vai “empilhar” as rotas filhas encontradas em app/.
        Por padrão, pode ficar sem cabeçalho (headerShown: false).
      */}
      <Stack screenOptions={{ headerShown: false }} />
    </AuthProvider>
  );
}