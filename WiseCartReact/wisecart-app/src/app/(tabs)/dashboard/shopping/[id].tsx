import MainContainer from '@/src/components/mainContainer';
import { useFetch } from '@/src/hooks/useFetch';
import { ProductViewModel, PurchaseViewModel, ShoppingViewModel, UnitOfMeasureViewModel } from '@/src/models/viewModel/models';
import { ShoppingService } from '@/src/services/shoppingService';
import { ProductService } from '@/src/services/productService';
import { useLocalSearchParams } from 'expo-router/build/hooks';
import { useEffect, useState } from 'react';
import { Alert, SafeAreaView, ScrollView, Text, TouchableOpacity, View } from 'react-native';
import ShoppingItemComponent from '@/src/components/shoppingItemComponent';
import PurchaseItemComponent from '@/src/components/purchaseItemComponent';
import { Loading } from '@/src/components/loading';
import CameraScanner from '@/src/components/cameraScanner';
import React from 'react';
import ProductComponent from '@/src/components/productComponent';
import { Ionicons } from '@expo/vector-icons';
import Countdown from '@/src/components/countdown';
import { router } from 'expo-router';
import { UomService } from '@/src/services/uomService';

export default function Shopping() {
  const { id } = useLocalSearchParams();
  const { data, loading, request, error } = useFetch();

  const [ shopping, setShopping ] = useState<ShoppingViewModel>();

  const [productModalVisible, setProductModalVisible] = useState(false);
  const [cameraModalVisible, setCameraModalVisible] = useState(false);
  const [productVM, setProductVM] = useState<ProductViewModel>();
  const [uomItems, setUomItems] = useState<UnitOfMeasureViewModel[]>([]);
  
  const getShopping = async() => {
    const result = await request(ShoppingService.getById, id);
    setShopping(result);
  }
  
   const getUom = async () => {
      const result = await request(UomService.getAll);
      setUomItems(result);
   }

  const updatePurchase = (updatedPurchase: PurchaseViewModel) => {
    setShopping(prevShopping => {
      if (!prevShopping) return prevShopping;
      
      return {
        ...prevShopping,
        purchases: prevShopping.purchases.map(p => 
          p.id === updatedPurchase.id ? updatedPurchase : p
        )
      };
    });
  }

  const deletePurchase = (deletedId: string) => {
    setShopping(prevShopping => 
      {
        if (!prevShopping) return prevShopping;
      
        return {
          ...prevShopping,
          purchases: prevShopping.purchases.filter(p => 
            p.id !== deletedId
          )
        };
      });
  }

  const handleScan = async (value: string) => {
    const result = await request(ProductService.get, value);
    let product = null;

    if (result.status == 404) {
      product = {
        code: value
      }
    }
    else {
      product = result;
    }

    setProductVM(product);
    setProductModalVisible(true);
  }

  const posPostPurchase = (newPurchase: PurchaseViewModel) => {
    setShopping(prevShopping => {
      if (!prevShopping) return prevShopping;
      
      return {
        ...prevShopping,
        purchases: [newPurchase, ...prevShopping.purchases] // newPurchase será o primeiro da lista
      };
    });
    
    setProductModalVisible(false);
  }

  const confirmCloseShopping = async () => {
    Alert.alert(
      'Confirmação',
      `Deseja encerrar as compras?`,
      [
        {
          text: 'Cancelar',
          style: 'cancel'
        },
        {
          text: 'Confirmar',
          onPress: async () => await updateDateEnd(),
          style: 'destructive'
        }
      ],
      { cancelable: true }
    )
  }

  const updateDateEnd = async () => {
    const result = await request(ShoppingService.UpdateDateEnd, shopping?.id, new Date().toLocaleString('sv-SE'));
    console.log(result)
    if (result.errors) {
      Alert.alert('Ocorreu um erro!', JSON.stringify(result.errors))
    }
    else {
      router.back();
    }
  }
  console.log('aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1 ' + id)
  useEffect(() => {
    getShopping();
    getUom();
  }, [])

  if (loading) {
    return <Loading />
  }

  const ShoppingConfig = (
    <View className='flex flex-1 justify-center items-center'>
      <Countdown dateIni={shopping?.dateStart.toString() ?? ''} />
      <View className='flex flex-row p-2 m-2 items-center justify-center'>
        <TouchableOpacity className='bg-slate-600 rounded-md p-2 items-center flex-1' onPress={confirmCloseShopping}>
          <Text className='text-white font-bold text-cente'>Encerrar compras</Text>
        </TouchableOpacity>
      </View>      
    </View>
  )

  return (
    <SafeAreaView style={{ flex: 1, position: 'relative' }}>
      <ScrollView className='pb-10 m-4' showsVerticalScrollIndicator={false} contentContainerStyle={{ paddingBottom: 120 }}>
        {/* Conteúdo rolável da tela de compras */}
        <View className='flex flex-1 items-center '>           
      
        {shopping ? (
            <ShoppingItemComponent 
              shopping={shopping} 
              title='Continuar compra'
              titleColor='#1f2937'
              config={ !shopping.dateEnd ? ShoppingConfig : ''}
            />
          ) : (
            <Text>Carregando...</Text>
          )}
  
          {shopping && Array.isArray(shopping.purchases) && shopping.purchases.length > 0 ? (
            shopping.purchases.map(item => (
              <PurchaseItemComponent key={item.id} purchase={item} onPurchaseUpdate={updatePurchase} onDelete={deletePurchase} editable={!shopping.dateEnd}/>
            ))
          ) : (
            <Text>Sem compras disponíveis.</Text>
          )}      

        </View>
                      
        <CameraScanner 
        modalVisible={cameraModalVisible}
        setModalVisible={setCameraModalVisible}
        hendleScan={handleScan}
        /> 
        
      </ScrollView>

      <ProductComponent 
              modalVisible={productModalVisible}
              productVM={productVM}
              visibleDelegate={setProductModalVisible}
              handlePostProduct={posPostPurchase}
              shoppingId={shopping?.id ?? ''}
              uomItems={uomItems}
            />

      {/* Botão fixo exclusivo para essa tela */}
      <View 
        className='absolute bottom-4 right-3 items-center'
        style={{display: shopping?.dateEnd ? 'none' : 'flex'}}
      >
        <TouchableOpacity
          className='w-full bg-yellow-500 rounded-md p-3 mb-2 items-center'
          onPress={() => setCameraModalVisible(true)}
        >
          <Ionicons name="barcode-outline" size={30} />
        </TouchableOpacity>
      </View>
    </SafeAreaView>
  );
  
  
}
