import React, { useState, useRef } from 'react';
import { Text, View, TouchableOpacity, Alert } from 'react-native';
import { CameraView, useCameraPermissions } from 'expo-camera';
import Modal from 'react-native-modal';

interface CameraScanProps {
  hendleScan: (value: string) => void;
  modalVisible: boolean;
  setModalVisible: (value: boolean) => void;
}

export default function CameraScanner({hendleScan, modalVisible, setModalVisible}: CameraScanProps) {

  const [permission, requestPermission] = useCameraPermissions();

  const barCodeLock = useRef(false);

  const handleOpenCamera = async () => {
    const { granted } = await requestPermission();

    if (!granted) {
      return Alert.alert('Camera', 'necessário habilitar o uso da câmera')
    }

    barCodeLock.current = false;
    setModalVisible(true);
  }

  const barCodeScanned = (value: string) => {
    if (!value || barCodeLock.current)
      return;

    barCodeLock.current = true;
    setModalVisible(false);
    hendleScan(value);    
  }

  return (
  <View>   
    <Modal
      isVisible={modalVisible}
      onBackdropPress={() => setModalVisible(false)}
      animationIn="fadeIn"
      animationOut="fadeOut">
          <CameraView 
          style={{flex: 1}} 
          facing='back'
          barcodeScannerSettings={{
            barcodeTypes: ['ean13']
          }}
          onBarcodeScanned={({ data }) => barCodeScanned(data)}
          />
          <TouchableOpacity 
            className='bg-blue-600 rounded-md p-3 mb-2 items-center'
            onPress={() => setModalVisible(false)}                    
          >
            <Text className="text-lg font-bold mb-4 color-white">
              Fechar
            </Text>
          </TouchableOpacity>
      </Modal>
  </View>
  )
}
