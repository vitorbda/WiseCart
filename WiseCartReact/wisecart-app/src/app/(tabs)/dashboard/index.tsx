import { Alert, Text, TouchableOpacity, View } from 'react-native';
import { useAuth } from '../../../contexts/AuthContext';
import { Loading } from '@/src/components/loading';
import MainContainer from '@/src/components/mainContainer';
import ModalComponent from '@/src/components/modalComponent';
import { useCallback, useEffect, useState } from 'react';
import { useFetch } from '@/src/hooks/useFetch';
import {MarketService} from '../../../services/marketService';
import {ShoppingService} from '../../../services/shoppingService';
import SelectComponent from '@/src/components/selectComponent';
import ShoppingItemComponent from '@/src/components/shoppingItemComponent';
import { ShoppingViewModel } from '@/src/models/viewModel/models';
import { useFocusEffect, useRouter } from 'expo-router';
import React from 'react';

export default function Dashboard() {
  const { user, loading } = useAuth(); 

  const [modalVisible, setModalVisible] = useState(false);
  const [marketItems, setMarketItems] = useState([]);
  const [shoppingItems, setShoppingItems] = useState<ShoppingViewModel[]>([]);
  const [selectedOption, setSelectedOption] = useState<string>('');

  const { data: response, loading: loadingFetch, request, error } = useFetch();

  const router = useRouter();
  

  const getMarket = async () => {
    const result = await request(MarketService.get);
    setMarketItems(result);
  }

  const getShopping = useCallback(async () => {
    const result = await request(ShoppingService.getShoppingsByUserId, user?.id);
    setShoppingItems(result);
  }, [user?.id]);

  const handleCart = (id: string) => {
    console.log('handleCart' + id)
    router.push(`/(tabs)/dashboard/shopping/${id}`);
    
  }

  const createShopping = async () => {
    const newShopping = {
      userId: user?.id,
      marketId: selectedOption
    };

    const result = await request(ShoppingService.create, newShopping);
    handleCart(result.id)
  }

  useEffect(() => {
    getMarket();
    getShopping();
  }, [])

  useFocusEffect(
    useCallback(() => {
      getShopping();
      console.log('Tela em foco');
      
      return () => {
        console.log('Tela perdeu o foco');
      };
    }, [getShopping])
  );
  

  if (loading) {
    return <Loading />
  }
  

  return (
    <MainContainer>
      
      <Text>Bem-vindo, {user?.username}</Text>    

      <View className="bg-white rounded-lg shadow-lg p-8 m-4 w-full items-center">
        <Text className="text-2xl font-bold mb-4">Iniciar compras</Text>
        
        <TouchableOpacity
                className={`bg-blue-600 rounded-md p-3 mb-2 items-center`}
                onPress={() => setModalVisible(true)}
              >
                <Text className='text-white font-bold'>
                  Iniciar
                </Text>
              </TouchableOpacity>
        
      </View>

      <ModalComponent 
        modalTitle='Mercado'
        isVisible={modalVisible}
        isVisibleDelegate={setModalVisible}
      >
        <View className='w-full items-center'>
          <View className='flex flex-row'>
            <SelectComponent
              selectedValue={selectedOption}
              onValueChange={(value) => setSelectedOption(value as string)}
              items={marketItems}
            />
          </View>
          <View className='flex flex-row'>
            <TouchableOpacity
              className='bg-green-600 rounded-md p-3 m-1 flex-1'
              onPress={() => createShopping()}
            >
              <Text className='text-white font-bold text-center'>
                Iniciar
              </Text>
            </TouchableOpacity>
          </View>
        
          
        </View>
        
      </ModalComponent>

      <View className='items-center'>
        <Text className='text-2xl font-bold mb-4'>Compras em andamento</Text>              
      </View>

      <View className='flex justify-center items-center w-full'>
      {
          shoppingItems.filter(x => !x.dateEnd).length === 0 
            ? <Text className='text-sm'>Sem dados</Text>
            : shoppingItems
                .filter(x => !x.dateEnd)
                .map(item => (
                  <ShoppingItemComponent 
                    shopping={item} 
                    handleButton={() => handleCart(item.id)} key={item.id}
                    title='Continuar compra'
                    titleColor='#16a34a'
                    buttonColor='#16a34a'
                    buttonText='Continuar'
                    />
                ))
        }
      </View>      

      <View className='items-center mt-4'>
        <Text className='text-2xl font-bold mb-4'>Compras anteriores</Text>
      </View>
      <View className='flex justify-center items-center w-full'>
        {
          shoppingItems.filter(x => x.dateEnd).length === 0 
            ? <Text className='text-sm'>Sem dados</Text>
            : shoppingItems
                .filter(x => x.dateEnd)
                .map(item => (
                  <ShoppingItemComponent 
                    shopping={item} 
                    handleButton={() => handleCart(item.id)} key={item.id}
                    title='Visualizar compra'
                    titleColor='#1f2937'
                    buttonColor='#475569'
                    buttonText='Visualizar'
                    />
                ))
        }         
      </View>

    </MainContainer>
  );
}
function useStore(arg0: (state: any) => any) {
  throw new Error('Function not implemented.');
}

