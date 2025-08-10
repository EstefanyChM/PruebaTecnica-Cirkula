import { createNativeStackNavigator } from '@react-navigation/native-stack';
import React from 'react';
import ShopsList from '../screens/ShopsList';

export type RootStackParamList = {
  Shops: undefined;
};

const Stack = createNativeStackNavigator<RootStackParamList>();

export default function Navigation() {
  return (
    <Stack.Navigator>
      <Stack.Screen 
        name="Shops" 
        component={ShopsList} 
        options={{ 
          title: 'Tiendas',
          headerStyle: {
            backgroundColor: '#00B8A9', 
          },
          headerTintColor: '#fff',
          headerTitleStyle: {
            fontWeight: 'bold',
          },
          headerTitleAlign: 'center',
        }} 
      />
    </Stack.Navigator>
  );
}