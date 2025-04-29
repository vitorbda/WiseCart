import { useState } from 'react';

export const useFetch = () => {
  // Estados para armazenar dados, loading e erros
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Função `request` que faz a chamada à API
  const request = async (apiFunc, ...args) => {
    setLoading(true);
    setError(null);
    
    try {
      const response = await apiFunc(...args);
      
      if (response.status === 204) {
        setData({ success: true, message: "Registro concluído com sucesso" });
        return { success: true };
      }
      const result = await response.json();
      setData(result);
      return result;
    } catch (err) {
      console.log(err)
      setError(err);
      throw err;
    } finally {
      setLoading(false);
    }
  };

  return { data, loading, error, request };
};