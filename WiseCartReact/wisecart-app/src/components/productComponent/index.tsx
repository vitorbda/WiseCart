import React, { useEffect, useRef, useState } from 'react';
import { View, Text, TouchableOpacity, TextInput } from 'react-native';
import ModalComponent from '../modalComponent';
import { ProductViewModel, PurchaseViewModel, UnitOfMeasureViewModel } from '@/src/models/viewModel/models';
import TextInputComponent from '../textInputComponent';
import SelectComponent from '../selectComponent';
import { useFetch } from '@/src/hooks/useFetch';
import {UomService} from '../../services/uomService';
import { ProductService } from '@/src/services/productService';
import { PurchaseService } from '@/src/services/purchaseService';

interface ProductProps {
    productVM?: ProductViewModel | null;
    modalVisible: boolean;
    visibleDelegate: (show: boolean) => void;
    handlePostProduct: (purchase: PurchaseViewModel) => void;
    shoppingId: string;
    uomItems: UnitOfMeasureViewModel[];
}

interface TextInputComponentRef {
  focus: () => void;
}

export default function ProductComponent({productVM, modalVisible, visibleDelegate, handlePostProduct, shoppingId, uomItems}: ProductProps) {

 const [name, setName] = useState(productVM?.name);
 const [code, setCode] = useState(productVM?.code);
 const [brands, setBrands] = useState(productVM?.brands);

 const [price, setPrice] = useState('');
 const [uom, setUom] = useState(uomItems.filter(x => x.abbreviation == 'un')[0]?.id ?? '');
 const [quantity, setQuantity] = useState('1');

 const { data, loading, request, error } = useFetch();

 const inputPriceRef = useRef<TextInputComponentRef>(null);
 const inputNameRef = useRef<TextInputComponentRef>(null);

 const postProduct = async () => {
    const product = {
        code: code,
        name: name,
        brands: brands
    }
    
    const result = await request(ProductService.createProduct, product);
    return result;
 }

 const postPurchase = async () => {
    const product = !productVM?.id ? await postProduct() : productVM;
    

    const purchase = {
        price: price,
        quantity: quantity,
        unitOfMeasureId: uom,
        productId: product.id,
        shoppingId: shoppingId
    }

    console.log(purchase)

    const result = await request(PurchaseService.CreatePurchase, purchase);
    
    handlePostProduct(result);
 }

 useEffect(() => {
  if (modalVisible) {
    setTimeout(() => {
      if (productVM?.id)
        inputPriceRef.current?.focus();
      else
        inputNameRef.current?.focus();
    }, 100);
  }
}, [modalVisible]);

 return (
   <ModalComponent
    modalTitle='Inserir produto'
    isVisible={modalVisible}
    isVisibleDelegate={visibleDelegate}
   >
    <View className="w-full">
              <View className='items-center justify-center w-full'>   
                          
                  <View className="flex flex-row">
                    <View className="rounded-md p-2 items-center flex-1">
                      <Text className="text-gray-600">Codigo</Text>
                      <TextInputComponent value={code ?? ''} editable={!productVM?.id} handleChange={(value) => setCode(value)}/>                  
                    </View>
                  </View>

                  <View className="flex flex-row">
                    <View className="flex-1 rounded-md p-2 items-center">
                      <Text className="text-gray-600">Produto</Text>
                      <TextInputComponent ref={inputNameRef} value={name ?? ''} editable={!productVM?.id} handleChange={(value) => setName(value)} type='text'/>                  
                    </View>
                    <View className="flex-1 ml-2 rounded-md p-2 items-center">
                      <Text className="text-gray-600">Marca</Text>
                      <TextInputComponent value={brands ?? ''} editable={!productVM?.id} handleChange={(value) => setBrands(value)} type='text'/>                  
                    </View>
                  </View>

                  <View className="flex flex-row justify-center items-center">
                    <View className="flex-1 rounded-md items-center">
                      <Text className="text-gray-600">Unidade de medida</Text>                      
                        <SelectComponent
                          selectedValue={uom}
                          onValueChange={(value) => setUom(value as string)}
                          items={uomItems}
                        />
                    </View>
                    <View className="flex-1 ml-2 rounded-md p-2 items-center">
                      <Text className="text-gray-600">Preço</Text>
                      <TextInputComponent ref={inputPriceRef} value={price} editable={true} handleChange={(value) => setPrice(value)}/>                  
                    </View>
                  </View>

                  <View className="flex flex-row">
                    <View className="flex-1 ml-2 rounded-md p-2 items-center">
                      <Text className="text-gray-600">Quantidade</Text>
                      <TextInputComponent value={quantity} editable={true} handleChange={(value) => setQuantity(value)}/>                  
                    </View>
                  </View>  
                  <View className="flex flex-row">
                  <TouchableOpacity className="bg-green-600 rounded-md p-3 flex-1" onPress={postPurchase}>
                    <Text className="text-white font-bold text-center">Salvar</Text>
                </TouchableOpacity>
              </View>                     
          </View>
        </View>
   </ModalComponent>
  );
}