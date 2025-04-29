import React from 'react';
import { useState } from 'react';
import { View, TouchableOpacity, Text, ViewProps } from 'react-native';
import Modal from 'react-native-modal';

interface MainContainerProps extends ViewProps	{
    children: React.ReactNode;
    modalTitle: string;
    isVisible: boolean;
    isVisibleDelegate: (show: boolean) => void;
}

export default function ModalComponent({ children, modalTitle, isVisible, isVisibleDelegate, ...rest } : MainContainerProps) {
    
    return (
    
        <Modal
          isVisible={isVisible}
          onBackdropPress={() => isVisibleDelegate(false)}
          animationIn="fadeIn"
          animationOut="fadeOut"
          {...rest}
        >
          <View className="p-6 rounded-lg w-11/12 self-center bg-white">
            <View className="items-center ">
              <Text className="text-lg font-bold">{modalTitle}</Text>
            </View>
            {children}
          </View>

        </Modal>
      );
}