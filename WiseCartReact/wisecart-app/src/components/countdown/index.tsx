import React, { useEffect, useState } from 'react';
import { Text, View } from 'react-native';

export default function Countdown({dateIni}: {dateIni: string}) {

    const [elapsedTime, setElapsedTime] = useState({
        hour: 0,
        minute: 0,
        second: 0
      });

    useEffect(() => {
      const dateStart = new Date(dateIni);
      
      const updateCountdown = () => {
        const now = new Date();
        const difference = now.getTime() - dateStart.getTime();
        
        const hour = Math.floor(difference / (1000 * 60 * 60));
        const minute = Math.floor((difference % (1000 * 60 * 60)) / (1000 * 60));
        const second = Math.floor((difference % (1000 * 60)) / 1000);

        const hourFormated = hour < 0 ? 0 : hour;
        const minuteFormated = minute < 0 ? 0 : minute;
        const secondFormated = second < 0 ? 0 : second;
        
        setElapsedTime(
          { 
            hour: hourFormated, 
            minute: minuteFormated, 
            second: secondFormated
          }
        );
      };

      updateCountdown();
      
      const intervalo = setInterval(updateCountdown, 1000);
      
      return () => clearInterval(intervalo);
    }, [dateIni]);

    const timeFormat = (value: number) => {
        const val = value.toString().padStart(2, '0');
        return val == '-1' ? '00' : val;
      };

 return (
   <View className='flex flex-row'>
    <Text className='font-bold text-center'>
      {timeFormat(elapsedTime.hour)}:
      {timeFormat(elapsedTime.minute)}:
      {timeFormat(elapsedTime.second)}
    </Text>
   </View>
  );
}