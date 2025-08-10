import { useQuery } from '@tanstack/react-query';
import { fetchShops } from './shops.api';

export function useShops(lat?: number, lng?: number) {
  return useQuery({
    queryKey: ['shops', lat, lng],
    queryFn: () => fetchShops(lat, lng),
    staleTime: 1000 * 60 * 2,
    retry: 1,
    enabled: typeof lat === 'number' && typeof lng === 'number',
  });
}