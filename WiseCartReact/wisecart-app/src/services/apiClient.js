import { API_CONFIG } from "../config/api";
import * as SecureStore from 'expo-secure-store';

export const apiClient = async (endpoint, options = {}) => {  
  const url = `${API_CONFIG.BASE_URL}${endpoint}`;
  
  // 1. Corrigido: SecureStore assíncrono
  const token = await SecureStore.getItemAsync('authToken');
  
  const headers = {
    ...API_CONFIG.HEADERS,
    ...options.headers,
    ...(token && { Authorization: `Bearer ${token}` }) // 2. Adiciona token condicionalmente
  };

  try {
    const response = await fetch(url, {
      ...options,
      headers,
      // 4. Garante que body é string se for objeto
      body: typeof options.body === 'object' ? JSON.stringify(options.body) : options.body
    });
    return response;
  } catch (error) {
    // 7. Log mais informativo
    console.error('API Request Failed:', {
      url,
      error: error.message,
      ...(error.response && { status: error.response.status })
    });
    throw error;
  }
};
