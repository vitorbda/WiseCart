import { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import * as SecureStore from 'expo-secure-store';
import { jwtDecode } from 'jwt-decode';

interface UserProps {
  username: string;
  role: string;
  id: string;
}

interface AuthContextType {
  user: UserProps | null;
  loading: boolean;
  login: (token: string) => void;
  logout: () => void;
}

// Criando o contexto de autenticação
const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider = ({ children }: AuthProviderProps) => {
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
        const decoded = jwtDecode<UserProps>(token); // Tipando a saída do jwtDecode
        setUser(decoded); // Definindo diretamente o tipo correto
      } catch (error) {
        await SecureStore.deleteItemAsync('authToken');
      } finally {
        setLoading(false);
      }
    };

    loadUser();
  }, []);

  const login = async (token: string) => {
    await SecureStore.setItemAsync('authToken', token);
    const decoded = jwtDecode<UserProps>(token); // Decodificando e tipando
    setUser(decoded);
  };

  const logout = async () => {
    await SecureStore.deleteItemAsync('authToken');
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, loading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

// Hook para acessar o contexto
export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};
