import { AxiosError } from "axios";
import { useEffect, useState } from "react";
import { axiosInstance } from "./axios";

export const useApiGet = <T,>(url: string) => {
  const [data, setData] = useState<T | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const fetchData = async () => {
    setLoading(true);
    try {
      const response = await axiosInstance.get(url);
      setData(response.data);
    } catch (e) {
      setError((e as AxiosError).message);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    void fetchData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return { data, loading, error };
};

export const useApiPut = <T,>(url: string) => {
  const [response, setResponse] = useState<T | null>(null);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const putData = async (data: T) => {
    setLoading(true);
    try {
      const response = await axiosInstance.put(url, data);
      setResponse(response.data);
    } catch (e) {
      setError((e as AxiosError).message);
    } finally {
      setLoading(false);
    }
  };

  return { putData, response, loading, error };
};
