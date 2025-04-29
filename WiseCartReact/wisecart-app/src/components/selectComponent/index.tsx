import React, { useEffect, useState } from 'react';
import { View } from 'react-native';
import DropDownPicker, { ItemType, ValueType } from 'react-native-dropdown-picker';

interface SelectComponentProps {
  selectedValue: string | null;
  onValueChange: (value: string | null) => void;
  items: { name: string; id: string }[];
  placeholder?: string;
}

export default function SelectComponent({ 
  selectedValue, 
  onValueChange, 
  items, 
  placeholder = "Selecione...",
  ...rest 
}: SelectComponentProps) {
  const [open, setOpen] = useState(false);
  const [value, setValue] = useState<ValueType | null>(selectedValue);
  const [formattedItems, setFormattedItems] = useState<ItemType<string>[]>([]);

  useEffect(() => {
    const convertedItems: ItemType<string>[] = items.map(item => ({
      label: item.name,
      value: item.id,
      labelStyle: { 
        fontSize: 14, // Adicionado fontSize obrigatório
        color: '#111827'
      }
    }));
    
    if (!selectedValue) {
      convertedItems.unshift({
        label: placeholder,
        value: '',
        labelStyle: {
          fontSize: 14, // Adicionado aqui também
          color: '#9CA3AF'
        }
      });
    }

    setFormattedItems(convertedItems);
  }, [items, selectedValue, placeholder]);

  useEffect(() => {
    setValue(selectedValue);
  }, [selectedValue]);

  return (
    <View className="w-full z-10">
      <DropDownPicker
        open={open}
        value={value}
        items={formattedItems}
        setOpen={setOpen}
        setValue={(callback) => {
          const newValue = callback(value);
          setValue(newValue);
          onValueChange(newValue as string | null);
        }}
        listMode="SCROLLVIEW"
        placeholder={placeholder}
        placeholderStyle={{
          fontSize: 14, // Adicionado fontSize
          color: '#9CA3AF'
        }}
        style={{
          backgroundColor: '#fff',
          borderColor: '#D1D5DB',
          borderRadius: 12,
          minHeight: 45,
        }}
        dropDownContainerStyle={{
          backgroundColor: '#fff',
          borderColor: '#D1D5DB',
          borderRadius: 12,
          marginTop: 4
        }}
        textStyle={{
          fontSize: 14,
          color: '#111827'
        }}
        {...rest}
      />
    </View>
  );
}