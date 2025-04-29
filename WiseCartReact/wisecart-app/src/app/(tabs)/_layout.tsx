import { Tabs, useRouter } from 'expo-router';
import { useAuth } from '../../contexts/AuthContext';
import { useEffect } from 'react';
import { Ionicons } from '@expo/vector-icons';
import React from 'react';

export default function TabsLayout() {
  const { user } = useAuth();
  const router = useRouter();

  useEffect(() => {
    if (!user) {
      // Se não está logado, manda para tela de login
      router.replace('/(public)/login');
    }
  }, [user]);

  return (
    <Tabs
      screenOptions={{
        headerShown: false, // Oculta o cabeçalho (opcional)
      }}
    >

      <Tabs.Screen
        name="home/index"
        options={{
          title: 'Home',
          tabBarIcon: ({color, size}) => (
            <Ionicons name='home-outline' color={color} size={size} />
          )
        }}
      />

      <Tabs.Screen
        name="dashboard"
        options={{
          title: 'Dashboard',
          tabBarIcon: ({color, size}) => (
            <Ionicons name='reader-outline' color={color} size={size} />
          )
        }}
      />

      <Tabs.Screen
        name="profile/index"
        options={{
          title: 'Profile',
          tabBarIcon: ({color, size}) => (
            <Ionicons name='person-outline' color={color} size={size} />
          )
        }}
      />

      <Tabs.Screen
        name="settings/index"
        options={{
          title: 'Settings',
          tabBarIcon: ({color, size}) => (
            <Ionicons name='settings-outline' color={color} size={size} />
          )
        }}
      />

      <Tabs.Screen
        name="shopping/index"
        options={{
          href: null
        }}
      />

    </Tabs>
  );
}