import { useFetch } from '@/src/hooks/useFetch';
import { UserService } from '@/src/services/userService';
import { Link, router } from 'expo-router';
import React, { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, Alert, ScrollView, SafeAreaView } from 'react-native';
import { useAuth } from '../../../contexts/AuthContext';

export default function LoginScreen() {
  const { login } = useAuth();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const { data: response, loading, request } = useFetch();
  
  const handleLogin = async () => {
    if (!username || !password) {
      return;
    }

    const obj = {
        username: username,
        password: password
    };

    try {
        const result = await request(UserService.login, obj);
        await login(result.token);
        router.replace('../(tabs)/dashboard');
    }
    catch (err) {
      if (err instanceof Error) {
        Alert.alert("Erro", err?.message || "Ocorreu um erro");
      }        
    }
  };

  return (
    <SafeAreaView style={{flex: 1}}>
        <ScrollView style={{flex: 1}} showsVerticalScrollIndicator={false}>
    <View className='flex items-center justify-center h-screen pb-10'>
    <View className='rounded-xl bg-slate-200 h-100 w-80 p-6 shadow-lg shadow-gray-800'>
      {/* Título */}
      <Text className='text-xl font-bold text-center mb-6'>Login</Text>

      {/* Campo Usuário */}
      <View className='mb-4'>
        <Text className='mb-1 font-medium'>Usuário</Text>
        <TextInput
          className='bg-white rounded-md p-2 border border-gray-300'
          placeholder='Digite seu usuário'
          value={username}
          onChangeText={setUsername}
        />
      </View>

      {/* Campo Senha */}
      <View className='mb-6'>
        <Text className='mb-1 font-medium'>Senha</Text>
        <TextInput
          className='bg-white rounded-md p-2 border border-gray-300'
          placeholder='Digite sua senha'
          secureTextEntry
          value={password}
          onChangeText={setPassword}
        />
      </View>

      {/* Botão Enviar */}
      <TouchableOpacity
        className={`${loading ? 'bg-blue-200' : 'bg-blue-600'} rounded-md p-3 mb-2 items-center`}
        onPress={handleLogin}
      >
        <Text className='text-white font-bold'>
            { loading ? 'Aguarde...' : 'Enviar'}
        </Text>
      </TouchableOpacity>

      {/* Botão Registrar */}
      <TouchableOpacity
        className={`bg-gray-500 rounded-md p-3 items-center`}
        onPress={() => router.push('/register')}
      >
            <Text className='text-white font-bold'>Registrar</Text>
      </TouchableOpacity>
    </View>
    </View>
    </ScrollView>
    </SafeAreaView>
    
  );
}
