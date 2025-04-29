import React, { forwardRef, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { TextInput, View } from 'react-native';
import type { KeyboardTypeOptions } from 'react-native';

interface TextInputProps {
  handleChange?: (value: string) => void;
  value: string;
  editable?: boolean;
  type?: string;    
}

const TextInputComponent = forwardRef(({
  handleChange,
  value,
  editable,
  type
}: TextInputProps, ref) => {
  const inputRef = useRef<TextInput>(null);

  const [internalValue, setInternalValue] = useState(value);
  
  // Expõe a função focus para o componente pai
  useImperativeHandle(ref, () => ({
    focus: () => {
      inputRef.current?.focus();
    }
  }));

  const handleFunction = (value: string) => {
    handleChange?.(value);
  };

  return (
    <View className='w-full rounded-xl border'
      style={{
        backgroundColor: editable ? 'white' : '#E5E7EB',
        opacity: editable ? 1 : 0.7,
        borderColor: '#D1D5DB'
      }}
    >
      <TextInput
        ref={inputRef}
        className='text-center'
        value={value}
        onChangeText={handleChange}
        keyboardType={type as KeyboardTypeOptions ?? 'numeric'}
        editable={!!editable}
      />
    </View>
  );
});

export default TextInputComponent;

