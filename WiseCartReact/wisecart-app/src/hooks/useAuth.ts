import { useEffect, useState } from 'react';
import * as SecureStore from 'expo-secure-store';
import jwtDecode from 'jwt-decode';

interface UserProps {
  username: string,
  role: string,
  id: string
}

export const useAuth = () => {
  const [user, setUser] = useState<UserProps | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadUser = async () => {
      const token = await SecureStore.getItemAsync('authToken');
      if (!token) {
        setLoading(false);
        return;
      }

      try {
        const decoded = <any>jwtDecode(token);
        setUser({
          username: decoded.username,
          role: decoded.role,
          id: decoded.id
        });
      } catch (error) {
        await SecureStore.deleteItemAsync('authToken');
      } finally {
        setLoading(false);
      }
    };

    loadUser();
  }, []); // Esse useEffect só vai rodar uma vez no início

  const login = async (token: string) => {
    await SecureStore.setItemAsync('authToken', token);
    const decoded = <any>jwtDecode(token);
    setUser({
      username: decoded.username,
      role: decoded.role,
      id: decoded.id
    });
  };

  const logout = async () => {
    await SecureStore.deleteItemAsync('authToken');
    setUser(null);
  };

  return { user, loading, login, logout };
};
