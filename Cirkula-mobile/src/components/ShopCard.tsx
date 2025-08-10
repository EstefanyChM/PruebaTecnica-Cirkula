import React from 'react';
import { Image, StyleSheet, Text, View } from 'react-native';
import { StoreResponse } from '../features/shops/shops.types';


const LocationIcon = () => <Text style={styles.icon}>📍</Text>;
const ClockIcon = () => <Text style={styles.icon}>🕒</Text>;

export default function ShopCard({ shop }: { shop: StoreResponse }) {
  return (
    <View style={styles.card}>
      {shop.bannerUrl ? (
        <Image source={{ uri: shop.bannerUrl }} style={styles.image} />
      ) : (
        <View style={[styles.image, styles.placeholder]} />
      )}
      <View style={styles.info}>
        <Text style={styles.name}>{shop.name}</Text>
        <View style={styles.metaContainer}>
          <View style={styles.metaRow}>
            <LocationIcon />
            <Text style={styles.meta}>{shop.distanceInKm ? shop.distanceInKm.toFixed(1) + 'km' : ''}</Text>
          </View>
          <View style={styles.metaRow}>
            <ClockIcon />
            <Text style={styles.meta}>{shop.openTime} / {shop.closeTime}</Text>
          </View>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  card: {
    backgroundColor: '#fff',
    borderRadius: 8,
    marginHorizontal: 16,
    marginBottom: 16,
    overflow: 'hidden',
    elevation: 2,
    shadowColor: '#000',
    shadowOpacity: 0.1,
    shadowRadius: 10,
    shadowOffset: { width: 0, height: 5 },
  },
  image: {
    width: '100%',
    height: 150,
    borderTopLeftRadius: 8,
    borderTopRightRadius: 8,
  },
  placeholder: {
    backgroundColor: '#e0e0e0', 
  },
  info: {
    padding: 12,
  },
  name: {
    fontWeight: '600',
    fontSize: 16,
    marginBottom: 8,
    color: '#333',
  },
  metaContainer: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  metaRow: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  meta: {
    color: '#666',
    fontSize: 12,
    marginLeft: 4,
  },
  icon: {
    fontSize: 12,
    marginRight: 2,
  },
});