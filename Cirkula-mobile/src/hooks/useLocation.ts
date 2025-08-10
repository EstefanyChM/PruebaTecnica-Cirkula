import * as Location from 'expo-location';
import { useEffect, useState } from 'react';

export default function useLocation() {
  const [coords, setCoords] = useState<{ lat: number; lng: number } | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    let mounted = true;

    (async () => {
      try {
        const { status } = await Location.requestForegroundPermissionsAsync();
        if (!mounted) return;
        if (status !== 'granted') {
          setError('Permiso de ubicación denegado');
          setLoading(false);
          return;
        }

        const loc = await Location.getCurrentPositionAsync({ accuracy: Location.Accuracy.Highest });
        if (!mounted) return;
        setCoords({ lat: loc.coords.latitude, lng: loc.coords.longitude });
      } catch (err: any) {
        setError(err.message || 'Error al obtener ubicación');
      } finally {
        setLoading(false);
      }
    })();

    return () => {
      mounted = false;
    };
  }, []);

  return { coords, loading, error } as const;
}