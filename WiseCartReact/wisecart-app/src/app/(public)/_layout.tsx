import { Stack, useRouter } from "expo-router";
import { useAuth } from "../../contexts/AuthContext";
import { useEffect } from "react";
import React from "react";

export default function AuthLayout() {
    const { user } = useAuth();
    const router = useRouter();
  
    useEffect(() => {
      if (user) {
        // Se o usuário já está logado, não faz sentido ficar aqui.
        router.replace('/(tabs)/home');
      }
    }, [user]);
  
    return (
      <Stack screenOptions={{ headerShown: false }}>
        {/* 
           Se o usuário não estiver logado, 
           ele vai conseguir acessar as telas de login e registro 
           que estiverem dentro de (auth)/*.tsx 
        */}
      </Stack>
    );
  }