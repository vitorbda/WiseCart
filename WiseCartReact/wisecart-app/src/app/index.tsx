import { useAuth} from '../contexts/AuthContext';
import { useRouter } from 'expo-router';
import { useEffect } from 'react';
import { Text, View } from 'react-native';
import '../styles/global.css';
import React from 'react';

export default function Index() {
  const { user, loading } = useAuth();
  const router = useRouter();

  useEffect(() => {
    // Assim que não estiver mais carregando, decide para onde vai
    if (!loading) {
      if (user) {
        // Usuário logado -> manda para a rota (tabs) -> home
        router.replace('/(tabs)/dashboard');
      } else {
        // Usuário não logado -> manda para (auth) -> login
        router.replace('/(public)/login');
      }
    }
  }, [loading, user]);

  // Enquanto está carregando (verificando token, etc.), podemos exibir algo básico
  if (loading) {
    return (
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text>Verificando autenticação...</Text>
      </View>
    );
  }

  return null;
}