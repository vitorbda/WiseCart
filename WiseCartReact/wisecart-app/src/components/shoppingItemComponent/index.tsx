import { PurchaseViewModel, ShoppingViewModel } from '@/src/models/viewModel/models';
import { Text, TouchableOpacity, View } from 'react-native';
import {
    formatDate
  } from '../../utils/utils';
import React from 'react';

  interface ShoppingCardProps {
    shopping: ShoppingViewModel;
    handleButton?: () => void; 
    buttonText?: string;
    buttonColor?: string;
    title: string;
    titleColor: string;   
    config?: React.ReactNode;
  }

  const getQuantityItens = (purchases: PurchaseViewModel[]): string => {
    if (!purchases) return '0.00'
    
    const total = purchases.reduce((acc, p) => {
      return p.unitOFMeasure_Abbreviation.toLowerCase() === "un"
        ? acc + p.quantity
        : acc + 1;
    }, 0);
    return total.toString();
  };

  const getValorTotal = (purchases: PurchaseViewModel[]): string => {
      if (!purchases) return '0.00'

    const total = purchases.reduce((acc, p) => {
      return p.unitOFMeasure_Abbreviation.toLowerCase() === "un"
        ? acc + p.quantity * p.price
        : acc + p.price;
    }, 0);
    return total.toFixed(2);
  };

  const isActive = (shopping: ShoppingViewModel): boolean =>
    !shopping.dateEnd;

export default function ShoppingItemComponent({shopping, handleButton, buttonText, buttonColor, title, titleColor, config} : ShoppingCardProps) {
  const onButtonPress = () => {
    if (handleButton) {
      handleButton();
    }
  };

 return (
    <View className="bg-white rounded-lg shadow-lg w-full items-center pt-4 mb-2">
        {/* Botão superior: "Continuar compra" */}
        <View className='w-full'>
            <View className="rounded-lg p-2 m-1" style={{backgroundColor: titleColor}}>
              <Text className="text-white font-bold text-center" >{title}</Text>
            </View>
        </View>
        
        <View className="w-full items-center">
            {/* Linha com "Data de início" e "Data de fim" */}
            <View className="flex flex-row items-center justify-between">
              <View className="bg-gray-100 rounded-md items-center flex-1">
                <Text className="text-gray-600">Data de início</Text>
                <Text className="text-gray-800 font-bold">
                    {formatDate(shopping.dateStart)}
                </Text>
              </View>
              <View className="bg-gray-100 rounded-md items-center flex-1">
                <Text className="text-gray-600">Data de fim</Text>
                <Text className="text-gray-800 font-bold">
                    {shopping.dateEnd ? formatDate(shopping.dateEnd) : "Em andamento"}
                </Text>
              </View>
            </View>

            {/* Linha com Mercado, Quantidade de itens e Valor Total */}
            <View className="flex flex-row mt-1 mb-1 justify-evenly items-center">
              <View className="bg-gray-100 rounded-md p-2 flex-1 items-center">
                <Text className="text-gray-600">Mercado</Text>
                <Text className="text-gray-800 font-bold">{shopping.market?.name}</Text>
              </View>
              <View className="bg-gray-100 rounded-md p-2 flex-1 items-center">
                <Text className="text-gray-600">Quantidade de itens</Text>
                <Text className="text-gray-800 font-bold">{getQuantityItens(shopping.purchases)}</Text>
              </View>
              
            </View>

            <View className="flex flex-row mb-2 justify-between items-center border rounded-xl">
              <View className="bg-gray-100 rounded-md p-2 items-center">
                <Text className="text-gray-600">Valor Total</Text>
                <Text className="text-gray-800 font-bold">{getValorTotal(shopping.purchases)}</Text>
              </View>
            </View>

            {
              config ?
              config
              : <></>
            }

            {
              handleButton ?
              <TouchableOpacity className="rounded-md p-3 w-7 mb-4 h-32"
                style={{backgroundColor: buttonColor}}
                onPress={() => onButtonPress()}            
                >
                  <Text className="text-white font-bold text-center">{buttonText}</Text>
                </TouchableOpacity>
              : <></>
            }
            
        </View>        
    </View>
  );
}