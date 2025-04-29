import { Button, Text, View } from 'react-native';
import { useAuth } from '../../../contexts/AuthContext';
import { Loading } from '@/src/components/loading';
import MainContainer from '@/src/components/mainContainer';
import React from 'react';

export default function Dashboard() {
  const { user, loading, logout } = useAuth(); 

  const handleLogout = async () => {
    await logout();
  };

  if (loading) {
    return <Loading />
  }

  return (
    <MainContainer>
      <Text>Bem-vindo, {user?.username}</Text>
      <Button title="Sair" onPress={handleLogout} />
      
    </MainContainer>
  );
}
