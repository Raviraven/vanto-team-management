import { RandomUserResponse } from "./types";
import { useApiGet } from "./base-hook";

export const useGetRandomUserData = () => {
  return useApiGet<RandomUserResponse>("https://randomuser.me/api/", false);
};
