import axios from "axios";
import { RandomUserResponse } from "./types";

export const GetRandomUserData = async () => {
  const result = await axios.get<RandomUserResponse>(
    "https://randomuser.me/api/",
  );
  return result.data;
};
