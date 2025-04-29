import { useEffect, useState } from 'react';
import { Alert, Pressable, Text, TouchableOpacity, View } from 'react-native';
import TextInputComponent from '../textInputComponent';
import { PurchaseViewModel } from '@/src/models/viewModel/models';
import { useFetch } from '@/src/hooks/useFetch';
import { PurchaseService } from '@/src/services/purchaseService';
import React from 'react';
import { Ionicons } from '@expo/vector-icons';

interface PurchaseItemProps {
    purchase: PurchaseViewModel;
    onPurchaseUpdate?: (updatedPurchase: PurchaseViewModel) => void;
    onDelete: (id: string) => void;
    editable?: boolean;
}

export default function PurchaseItemComponent({purchase, onPurchaseUpdate, onDelete, editable} : PurchaseItemProps) {

  const [price_, setPrice] = useState(purchase.price.toString());
  const [quantity_, setQuantity] = useState(purchase.quantity.toString());
  const [total_, setTotal] = useState('');

  const { data, loading, request, error } = useFetch();

  const changePurchase = async (updatedPurchase: PurchaseViewModel) => {
      await request(PurchaseService.UpdatePurchase, updatedPurchase);
  }
  
  const changeTotal = () => {
    const total = purchase.unitOFMeasure_Abbreviation.toLocaleLowerCase() === 'un'
      ? parseFloat(quantity_) * parseFloat(price_)
      : parseFloat(price_);

    const totalString = total.toFixed(2).toString();

    setTotal(totalString);
    if (onPurchaseUpdate) {
      const updatedPurchase = {
        ...purchase,
        price: parseFloat(price_),
        quantity: parseFloat(quantity_),
        total: total
      };

      changePurchase(updatedPurchase);
      onPurchaseUpdate(updatedPurchase);
    }
  }

  const deleteFetch = async () => {
    const result = await request(PurchaseService.DeletePurchase, purchase.id);

    if (result || result.success) {
      Alert.alert('Sucesso!')
      onDelete(purchase.id);
    }
      
  }

  const confirmDelete = async () => {
    Alert.alert(
      'Confirmação',
      `Deseja deletar o item ${purchase.product.name}?`,
      [
        {
          text: 'Cancelar',
          style: 'cancel'
        },
        {
          text: 'Confirmar',
          onPress: async () => await deleteFetch(),
          style: 'destructive'
        }
      ],
      { cancelable: true }
    )
  }

  useEffect(() => {
    changeTotal();
  }, [price_, quantity_])

  return (
      <View className="bg-white rounded-lg shadow-lg w-full items-center pt-4 mb-2 p-1">
          <View className='w-full'>
              <View className="bg-green-600 rounded-lg p-2 m-1"
                style={{backgroundColor: editable? '#16a34a' : '#1f2937'}}
              >
                <View className='flex flex-row justify-between'>
                    <Text className="text-white font-bold flex-shrink flex-1"
                      style={{textAlign: editable? 'left' : 'center'}}
                    >{purchase.product.name} - {purchase.product.brands}</Text>
                    <TouchableOpacity 
                      className='' 
                      onPress={confirmDelete}
                      style={{display: editable? 'flex' : 'none'}}
                      >
                      <Ionicons name='trash-outline' size={20} color={'#ffff'}/> 
                    </TouchableOpacity>                          
                </View>                              
              </View>
          </View>
          
          <View className="m-1 w-full p-2">
              <View className="flex-row mt-1 justify-center">
                <View className="flex-1 rounded-md p-2 items-center">
                  <Text className="text-gray-600">Preço</Text>
                  <TextInputComponent value={price_} handleChange={(value) => setPrice(value)} editable={editable}/>                  
                </View>
                <View className="flex-1 bg-gray-100 rounded-md p-2 items-center">
                  <Text className="text-gray-600">Quantidade</Text>
                  <TextInputComponent value={quantity_} editable={editable} handleChange={(value) => setQuantity(value)}/>
                </View>
                <View className="flex-1 rounded-md p-2 items-center">
                  <Text className="text-gray-600">Un de medida</Text>
                  <TextInputComponent value='un' />
                </View>
              </View>
  
              <View className="flex-row mt-1 justify-center">                                          
                <View className="bg-gray-100 rounded-md p-2 w-[30%] items-center">
                  <Text className="text-gray-600">Total</Text>
                  <Text className="text-gray-800 font-bold">{total_}</Text>
                </View>
              </View>              
          </View>        
      </View>
    );
}