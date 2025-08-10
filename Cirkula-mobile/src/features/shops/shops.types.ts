export interface StoreResponse {
  id: number;
  name: string;
  bannerUrl?: string;
  latitude: number;
  longitude: number;
  openTime: string;
  closeTime: string;
  distanceInKm: number;
  isOpen: boolean;
}

export interface StoresWrapperResponse {
  stores: StoreResponse[];
}
