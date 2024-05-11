import { RootState } from "./store";
import { useSelector } from "react-redux";

export const useMembers = () => {
  return useSelector((state: RootState) => state.members.members);
};

export const useRefetchMembers = () => {
  return useSelector((state: RootState) => state.members.refetch);
};
