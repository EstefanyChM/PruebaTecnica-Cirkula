import React from 'react';
import { ActivityIndicator, FlatList, RefreshControl, StyleSheet, Text, View } from 'react-native';
import ShopCard from '../components/ShopCard';
import { useShops } from '../features/shops/shops.hooks';
import useLocation from '../hooks/useLocation';

export default function ShopsList() {
  const { coords, loading: locLoading, error: locError } = useLocation();
  const { data: shops, isLoading, error, refetch, isRefetching } = useShops(coords?.lat, coords?.lng) as any;
 
  const loading = locLoading || isLoading;
/*   console.log('*******');
  console.log((error as any)?.message);
  console.log(locError );
  console.log('* * * * * * *'); */

  const err = locError || (error as any)?.message;

  if (loading) {
    return (
      <View style={styles.center}>
        <ActivityIndicator size="large" />
      </View>
    );
  }

  if (err) {
    return (
      <View style={styles.center}>
        <Text style={styles.errorText}>Error: {err}</Text>
        <Text onPress={() => refetch()}>Tocar para reintentar</Text>
      </View>
    );
  }

  return (
    <FlatList
      contentContainerStyle={styles.list}
      data={shops}
      keyExtractor={(item) => String(item.id)}
      refreshControl={<RefreshControl refreshing={isRefetching} onRefresh={() => refetch()} />}
      renderItem={({ item }) => <ShopCard shop={item} />}
      ListEmptyComponent={() => (
        <View style={styles.center}>
          <Text>No hay tiendas cercanas</Text>
        </View>
      )}
    />
  );
}

const styles = StyleSheet.create({
  list: { padding: 12 },
  center: { flex: 1, justifyContent: 'center', alignItems: 'center', padding: 20 },
  errorText: { color: 'red', marginBottom: 8 },
});