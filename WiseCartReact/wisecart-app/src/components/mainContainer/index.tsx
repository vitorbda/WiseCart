import React from 'react';
import { SafeAreaView, ScrollView, View, ViewProps } from 'react-native';

interface MainContainerProps extends ViewProps	{
    children: React.ReactNode;
}

export default function MainContainer({ children, ...rest } : MainContainerProps) {
 return (
   <SafeAreaView {...rest} >    
    <ScrollView showsVerticalScrollIndicator={false}>
        <View className='flex items-center h-full pb-10 m-4'>
          {children}
        </View>                        
    </ScrollView>    
   </SafeAreaView>
  );
}