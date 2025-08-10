import api from '../../services/api';
import { StoresWrapperResponse } from './shops.types';

export async function fetchShops(lat?: number, lng?: number) {
  // ejemplo: /shops?lat=...&lng=...
  const params: Record<string, string | number> = {};
  if (lat != null && lng != null) {
    params.lat = lat;
    params.lng = lng;
  }

  const { data } = await api.get<StoresWrapperResponse>('/GetAllWithDetails', { params });

  return data.stores ?? [];;
}